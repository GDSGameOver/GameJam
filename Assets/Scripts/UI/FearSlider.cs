using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Cradle _cradle;
    private float _duration = 0.5f;
    private float _newSliderValue = 0;
    private bool isPlayerDead = false;

    private Coroutine _changeValue;

    private void OnEnable()
    {
        _cradle.HPChangedNormalized += SetHP;
    }

    private void OnDisable()
    {
        _cradle.HPChangedNormalized -= SetHP;
    }


    private void SetHP(float hp)
    {
        hp = 1 - hp;
        if (isPlayerDead)
            return;

        if (hp >= 1)
            isPlayerDead = true;

        if (_changeValue != null)
        {
            if (Mathf.Abs(hp - _newSliderValue) < 0.05)
            {
                _newSliderValue = hp;
            }
            else
            {
                StopCoroutine(_changeValue);
                _changeValue = null;
            }
        }

        if (_changeValue == null)
            _changeValue = StartCoroutine(ChangeValue(hp));
    }

    private IEnumerator ChangeValue(float newSliderValue)
    {
        float elapsedTime = 0;
        float currentSliderValue = _slider.value;
        _newSliderValue = newSliderValue;

        while (elapsedTime < _duration)
        {
            float nextValue = Mathf.Lerp(currentSliderValue, _newSliderValue, elapsedTime / _duration);
            _slider.value = nextValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _changeValue = null;
    }
}

