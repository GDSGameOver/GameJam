using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CrySliderController : MonoBehaviour
{
    [SerializeField] private Slider _amountController;
    private float _duration = 1f;

    public void IncreaseValueInSlider()
    {
        StartCoroutine(ChangeValueBySegment(_amountController.value + 10));
    }

    public void ReduceValueInSlider()
    {
        StartCoroutine(ChangeValueBySegment(_amountController.value - 10));
    }

    private IEnumerator ChangeValueBySegment(float newSliderFillValue)
    {
        float elapsedTime = 0;
        float currentSliderValue = _amountController.value;

        while (elapsedTime < _duration)
        {
            float nextValue = Mathf.Lerp(currentSliderValue, newSliderFillValue, elapsedTime / _duration);
            _amountController.value = nextValue;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
