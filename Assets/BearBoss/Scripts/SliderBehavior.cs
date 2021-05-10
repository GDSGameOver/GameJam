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
    public event UnityAction BossNighmareLevelEmpty;

    [SerializeField] private Slider _amountControllerFear;
    [SerializeField] private Slider _amountControllerNighmare;
    [SerializeField] private Animator _nightmareBearIconAnimator;
    [SerializeField] private Cradle _cradle;
    [SerializeField] private Button _buttonSwing;
    [SerializeField] private Animator _crandleAnimator;
    [SerializeField] private Button _nightmareBearIcon;
    [SerializeField] private Spine _spine;
    [SerializeField] private AudioSource[] _bossPainSound;
    [SerializeField] private AudioSource _cradleCrouchSound;
    private float _duration = 1f;
    private float _increaseFearValueByTime;
    private float _increaseNightmareValueBySpine;
    private float _increaseNightmareValueByTime;
    private float _reduceFearBySwing;
    private float _reduceNighmareByHit;
    private float _flyBoneDamage;
    private float _bigSkullDamage;
    private float _flySkullDamage;
    private float _bossDamage;
    private float _clawDamage;
    private float _whillDamage;
    private bool _modeEasy;
    private bool _modeNormal;
    private bool _modeHard;
    


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

    private void Start()
    {

     _modeEasy = PlayerPrefs.GetInt("Easy") == 1;
     _modeNormal = PlayerPrefs.GetInt("Normal") == 1;
     _modeHard = PlayerPrefs.GetInt("Hard") == 1;
        
        if (_modeEasy)
        {
            _flyBoneDamage = 5;
            _clawDamage = 5;
            _flySkullDamage = 10;
            _whillDamage = 15;
            _bigSkullDamage = 20;
            _bossDamage = 30;

            _increaseNightmareValueBySpine = 1;
            _increaseNightmareValueByTime = 0;
            _increaseFearValueByTime = 0;
            _reduceFearBySwing = 25;
            _reduceNighmareByHit = 4;
        }
        if (_modeNormal)
        {
            _flyBoneDamage = 7;
            _clawDamage = 10;
            _flySkullDamage = 15;
            _whillDamage = 20;
            _bigSkullDamage = 25;
            _bossDamage = 35;

            _increaseNightmareValueBySpine = 2;
            _increaseNightmareValueByTime = 0;
            _increaseFearValueByTime = 1;
            _reduceFearBySwing = 20;
            _reduceNighmareByHit = 3;
        }
        if (_modeHard)
        {
            _flyBoneDamage = 10;
            _clawDamage = 10;
            _flySkullDamage = 20;
            _whillDamage = 25;
            _bigSkullDamage = 30;
            _bossDamage = 40;

            _increaseNightmareValueBySpine = 2;
            _increaseNightmareValueByTime = 2f;
            _increaseFearValueByTime = 2f;
            _reduceFearBySwing = 15;
            _reduceNighmareByHit = 3;
        }
    }

    private void IncreaseFearByFlyBoneAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + _flyBoneDamage));
    }

    private void IncreaseFearByClawAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + _clawDamage));
    }

    private void IncreaseFearByFlySkullAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + _flySkullDamage));
    }

    private void IncreaseNightmareBySpineTouch()
    {
        StartCoroutine(ChangeValueNightmareLevelBySegment(_amountControllerNighmare.value + _increaseNightmareValueBySpine));
    }

    private void IncreaseFearByWhillAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + _whillDamage));
    }

    private void IncreaseFearByBigSkullLeftAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + _bigSkullDamage));
    }

    private void IncreaseFearByBossAttack()
    {
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value + _bossDamage));
    }

    public void IncreaseFearWithTime()
    {
        _amountControllerFear.value += _increaseFearValueByTime * Time.deltaTime;
        if (_amountControllerFear.value >= 100)
        {
            _crandleAnimator.SetTrigger("Death");
        }
    }

    public void ReduceFearBySwing()
    {
        _crandleAnimator.SetTrigger("Swing");
        _cradleCrouchSound.Play();
        StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value - _reduceFearBySwing));
        if (_amountControllerNighmare.value <= 0)
        {
            BossNighmareLevelEmpty?.Invoke();
        }
    }

    public void IncreaseNightmareLevelWithTime()
    {
        _amountControllerNighmare.value += _increaseNightmareValueByTime * Time.deltaTime;
    }

    private IEnumerator ChangeValueNightmareLevelBySegment(float newSliderFillValue)
    {
        float elapsedTime = 0;
        float currentSliderValue = _amountControllerNighmare.value;
        while (elapsedTime < _duration)
        {
            float nextValue = Mathf.Lerp(currentSliderValue, newSliderFillValue, elapsedTime / _duration);
            _amountControllerNighmare.value = nextValue;
            Debug.Log(_amountControllerNighmare.value);
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
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void Update()
    {
      IncreaseFearWithTime();
      IncreaseNightmareLevelWithTime();
      BossDeathTrigger();
    }

    private void ReduceNightmareBossLevel()
    {
       _bossPainSound[Random.Range(0, 1)].Play();
       StartCoroutine(ChangeValueNightmareLevelBySegment(_amountControllerNighmare.value - _reduceNighmareByHit));
       CheckNightMareLevelToCallBoss();
    }

    private void CheckNightMareLevelToCallBoss()
    {
        if (_amountControllerNighmare.value <= 75 && _amountControllerNighmare.value >= 50)
        {
            NightMareLevelWentdownLess75?.Invoke();
        }
      //  if (_amountControllerNighmare.value <= 50 && _amountControllerNighmare.value >= 25)
      //  {
      //      NightMareLevelWentdownLess50?.Invoke();
       // }
        if (_amountControllerNighmare.value < 25)
        {
            NightMareLevelWentdownLess25?.Invoke();
        }
    }

    private void BossDeathTrigger()
    {
        if (_amountControllerNighmare.value <= 0)
        {
            BossNighmareLevelEmpty?.Invoke();
        }
    }
}
