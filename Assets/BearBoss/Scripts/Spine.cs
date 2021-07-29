using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spine : MonoBehaviour
{
    public event UnityAction TouchedToBossIcon;
    public event UnityAction Destroyed;

    [SerializeField] private Transform _pointToMove;
    [SerializeField] private int _numberOfHits;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Button _buttonSpineDestroy;
    [SerializeField] private Inputs _inputs;

    private float _speed;
    private Animator _animator;

    private void OnEnable()
    {
        _buttonSpineDestroy.onClick.AddListener(HitSpine);
    }

    private void OnDisable()
    {
        _buttonSpineDestroy.onClick.RemoveListener(HitSpine);
    }

    void Start()
    {
        _speed = 1;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointToMove.position, _speed * Time.deltaTime);
        Debug.Log(_speed);
    }

    public void TriggerToHideBoss()
    {
        Destroyed?.Invoke();
        _numberOfHits = 0;
        _speed = .5f;
        transform.position = _startPoint.position;
        gameObject.SetActive(false);
    }

    private void HitSpine()
    {
        if (_inputs.CanDamaging)
        {
            _numberOfHits++;
            _animator.SetTrigger("Hit");
            if (_numberOfHits > 15)
            {
                _animator.SetTrigger("Death");
            }
        }
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BossIcon bossIcon))
        {
            TouchedToBossIcon?.Invoke();
        }
    }
    
}
