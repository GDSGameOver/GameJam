using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightmareSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Boss _boss;
    private float _duration = 0.5f;
    private Coroutine _changeValue;

    private void OnEnable()
    {
        _boss.HPChangedNormalized += SetHP;
    }

    private void OnDisable()
    {
        _boss.HPChangedNormalized -= SetHP;
    }

    private void SetHP(float hp)
    {
        if (_changeValue != null)
            StopCoroutine(_changeValue);
        _changeValue = StartCoroutine(ChangeValue(hp));
    }

    private IEnumerator ChangeValue(float newSliderFillValue)
    {
        float elapsedTime = 0;
        float currentSliderValue = _slider.value;
        while (elapsedTime < _duration)
        {
            float nextValue = Mathf.Lerp(currentSliderValue, newSliderFillValue, elapsedTime / _duration);
            _slider.value = nextValue;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _changeValue = null;
    }
}
