﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderBehavior : MonoBehaviour
{
    [SerializeField] private Slider _amountControllerFear;
    [SerializeField] private Slider _amountControllerNighmare;
    [SerializeField] private NightmareBearIcon _nightmareBearIcon;
    [SerializeField] private Animator _nightmareBearIconAnimator;
    [SerializeField] private Cradle _cradle;
    [SerializeField] private Animator _crandleAnimator;
    [SerializeField] private Collider2D _nightmareBearIconCollider;
    [SerializeField] private Collider2D _cradleCollider;
    private float _duration = 1f;
    private float _stressLevelAfterVictory;

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
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000)), Vector2.zero);
        if (Input.GetMouseButton(1) && hit.collider == _cradleCollider)
        {
            _crandleAnimator.SetTrigger("Swing");
            StartCoroutine(ChangeValueFearBySegment(_amountControllerFear.value - 0.5f));
        }
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
      ReduceNightmareBossLevel();
      ReduceFearBySwing();
      IncreaseNightmareLevelWithTime();
    }

    private void ReduceNightmareBossLevel()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000)), Vector2.zero);
        if (Input.GetMouseButton(0) && hit.collider == _nightmareBearIconCollider)
        {
            _nightmareBearIconAnimator.SetTrigger("Strike");
            StartCoroutine(ChangeValueNightmareLevelBySegment(_amountControllerNighmare.value - 1));
        }
    }
}