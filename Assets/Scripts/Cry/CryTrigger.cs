using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class CryTrigger : MonoBehaviour
{
    [SerializeField] private Cradle _cradle;
    [SerializeField] private GameObject _reduceVolume;
    [SerializeField] private Slider _amountController;
    [SerializeField] private Animator _crandleAnimator;
    [SerializeField] private CountDownTimer _countDownTimer;
    private Collider2D _colliderOfReduceVolume;
    private bool _isVolumeIncrease;
    private AudioSource _audioSource;
    private float _duration = 1f;
    private float _stressLevelAfterVictory;

    void Start()
    {
        _colliderOfReduceVolume = _reduceVolume.GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000)), Vector2.zero);
        if (Input.GetMouseButton(1) && hit.collider == _colliderOfReduceVolume)
        {
            _crandleAnimator.SetTrigger("Swing");
            StartCoroutine(ChangeValueBySegment(_amountController.value - 1));
            StartCoroutine(ReduceVolume());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            if (_audioSource.volume == 0)
            {
                _audioSource.Play();
            }
            _isVolumeIncrease = true;
            StartCoroutine(IncreaseVolume());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(ChangeValueBySegment(_amountController.value + 10));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            _isVolumeIncrease = false;
        }
    }

    private IEnumerator IncreaseVolume()
    {
        while (_isVolumeIncrease == true)
        {
            _audioSource.volume += 1f * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ReduceVolume()
    {
        while (_isVolumeIncrease == false)
        {
            _audioSource.volume -= 1f * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ChangeValueBySegment(float newSliderFillValue)
    {
        float elapsedTime = 0;
        float currentSliderValue = _amountController.value;
        while (elapsedTime < _duration)
        {
            float nextValue = Mathf.Lerp(currentSliderValue, newSliderFillValue, elapsedTime / _duration);
            _amountController.value = nextValue;
            _stressLevelAfterVictory = _amountController.value;
            elapsedTime += Time.deltaTime;
            if (_amountController.value >= 100)
            {
                _crandleAnimator.SetTrigger("Death");
            }
            yield return null;
        }
    }

    public float GetStessLevel()
    {
        return _stressLevelAfterVictory;
    }
}
