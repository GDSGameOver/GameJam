using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CountDownTimer : MonoBehaviour
{
    public Text TimerText;
    public float CurrentTime;
    private float _seconds;
    private float _minutes;

    public event UnityAction WinConditionCompleted;
    public event UnityAction StressTimeGetted;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (_minutes < 3)
        {
            CurrentTime += Time.deltaTime;
            _seconds = ((int)CurrentTime % 60);
            _minutes = ((int)CurrentTime / 60 % 60);

            TimerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
            yield return null;
        }
        if (_minutes >= 3)
        {
            WinConditionCompleted?.Invoke();
            StressTimeGetted?.Invoke();
        }
    }
}
