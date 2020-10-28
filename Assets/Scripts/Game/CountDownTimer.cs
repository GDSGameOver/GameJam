using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text TimerText;
    public float CurrentTime;
    private float _seconds;
    private float _minutes;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (_minutes<10)
        {
            CurrentTime += Time.deltaTime;
            _seconds = ((int)CurrentTime % 60);
            _minutes = ((int)CurrentTime / 60 % 60);

            TimerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
            yield return null;
        }
    }
}
