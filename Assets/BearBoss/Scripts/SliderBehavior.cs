using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class SliderBehavior : MonoBehaviour
{
    public event UnityAction NightMareLevelWentdownLess75;
    public event UnityAction NightMareLevelWentdownLess50;
    public event UnityAction NightMareLevelWentdownLess25;

    [SerializeField] private Slider _amountControllerFear;
    [SerializeField] private Slider _amountControllerNighmare;
    [SerializeField] private Animator _nightmareBearIconAnimator;
    [SerializeField] private Cradle _cradle;
    [SerializeField] private Button _buttonSwing;
    [SerializeField] private Animator _crandleAnimator;
    [SerializeField] private Button _nightmareBearIcon;
    [SerializeField] private Spine _spine;
    private float _duration = 1f;
    private float _stressLevelAfterVictory;

    private void OnEnable()
    {
        _nightmareBearIcon.onClick.AddListener(ReduceNightmareBossLevel);
        _buttonSwing.onClick.AddListener(ReduceFearBySwing);
        _spine.TouchedToBossIcon += IncreaseNightmareBySpineTouch;
        _cradle.DamagedByClaw += IncreaseFearByClawAttack;
        _cradle.DamagedByWhill += IncreaseFearByWhillAttack;
        _cradle.DamagedByBigSkull += IncreaseFearByBigSkullLeftAttack;
        _cradle.DamagedByBoss += IncreaseFearByBossAttack;
        _cradle.DamagedByFlySkull += IncreaseFearByFlySkullAttack;
        _cradle.DamagedByFlyBone += IncreaseFearByFlyBoneAttack;
    }

    private void OnDisable()
    {
        _nightmareBearIcon.onClick.RemoveListener(ReduceNightmareBossLevel);
        _buttonSwing.onClick.RemoveListener(ReduceFearBySwing);
        _spine.TouchedToBossIcon -= IncreaseNightmareBySpineTouch;
        _cradle.DamagedByClaw -= IncreaseFearByClawAttack;
        _cradle.DamagedByWhill -= IncreaseFearByWhillAttack;
        _cradle.DamagedByBigSkull -= IncreaseFearByBigSkullLeftAttack;
        _cradle.DamagedByBoss -= IncreaseFearByBossAttack;
        _cradle.DamagedByFlySkull -= IncreaseFearByFlySkullAttack;
        _cradle.DamagedByFlyBone -= IncreaseFearByFlyBoneAttack;
    }

    private void IncreaseFearByFlyBoneAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + 1));
    }

    private void IncreaseFearByClawAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + 5));
    }

    private void IncreaseFearByFlySkullAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + 20));
    }

    private void IncreaseNightmareBySpineTouch()
    {
        StartCoroutine(ChangeValueNightmareLevelBySegment(_amountControllerNighmare.value + 1));
    }

    private void IncreaseFearByWhillAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + 20));
    }

    private void IncreaseFearByBigSkullLeftAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + 5));
    }

    private void IncreaseFearByBossAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + 10));
    }

    public void IncreaseValueInSlider()
    {
        StartCoroutine(ChangeValueNightmareLevelBySegment(_amountControllerNighmare.value + 10));
    }

    public void IncreaseFearWithTime()
    {
        _amountControllerFear.value += 1 * Time.deltaTime;
        if (_amountControllerFear.value >= 100)
        {
            _crandleAnimator.SetTrigger("Death");
        }
    }

    public void ReduceFearBySwing()
    {
            _crandleAnimator.SetTrigger("Swing");
            StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value - 0.5f));
    }

    public void IncreaseNightmareLevelWithTime()
    {
        _amountControllerNighmare.value += 0.1f * Time.deltaTime;
    }

    private IEnumerator ChangeValueNightmareLevelBySegment(float newSliderFillValue)
    {
        float elapsedTime = 0;
        float currentSliderValue = _amountControllerNighmare.value;
        while (elapsedTime < _duration)
        {
            float nextValue = Mathf.Lerp(currentSliderValue, newSliderFillValue, elapsedTime / _duration);
            _amountControllerNighmare.value = nextValue;
            _stressLevelAfterVictory = _amountControllerNighmare.value;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }

    private IEnumerator ChangeValueFearBySegment(float newSliderFillValue)
    {
        float elapsedTime = 0;
        float currentSliderValue = _amountControllerFear.value;
        while (elapsedTime < _duration)
        {
            float nextValue = Mathf.Lerp(currentSliderValue, newSliderFillValue, elapsedTime / _duration);
            _amountControllerFear.value = nextValue;
            _stressLevelAfterVictory = _amountControllerFear.value;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void Update()
    {
      IncreaseFearWithTime();
      IncreaseNightmareLevelWithTime();
    }

    private void ReduceNightmareBossLevel()
    {
            StartCoroutine(ChangeValueNightmareLevelBySegment(_amountControllerNighmare.value - 1));
            CheckNightMareLevelToCallBoss();
    }

    private void CheckNightMareLevelToCallBoss()
    {
        if (_amountControllerNighmare.value <= 75 && _amountControllerNighmare.value >= 50)
        {
            NightMareLevelWentdownLess75?.Invoke();
        }
        if (_amountControllerNighmare.value <= 50 && _amountControllerNighmare.value >= 25)
        {
            NightMareLevelWentdownLess50?.Invoke();
        }
        if (_amountControllerNighmare.value < 25)
        {
            NightMareLevelWentdownLess25?.Invoke();
        }
    }
}
