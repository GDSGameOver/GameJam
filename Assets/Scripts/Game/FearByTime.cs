using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearByTime : MonoBehaviour
{
    [SerializeField] private Cradle _cradle;
    [SerializeField] private FearByTimeSetting _setting;
    private float _fearValueByTime;
    private float elapsedTime = 0;

    private void Start()
    {
        _fearValueByTime = _setting.Values[PlayerPrefs.GetInt("Difficult", 0)];
        if (_fearValueByTime == 0)
            enabled = false;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1)
        {
            elapsedTime--;
            _cradle.TakeDamage(_fearValueByTime);
        }
    }

    
}
