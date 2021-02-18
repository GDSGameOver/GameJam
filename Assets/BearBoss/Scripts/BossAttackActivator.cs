using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossAttackActivator : MonoBehaviour
{
    public event UnityAction BossAttackActivated;


    [SerializeField] SliderBehavior _sliderBehavior;
    private bool _bossAttackThenNighmareLevelLess75 = false;
    private bool _bossAttackThenNighmareLevelLess50 = false;
    private bool _bossAttackThenNighmareLevelLess25 = false;

    private void OnEnable()
    {
        _sliderBehavior.NightMareLevelWentdownLess75 += ActivateBossThenNightMareLess75;
    }

    private void OnDisable()
    {
        _sliderBehavior.NightMareLevelWentdownLess75 -= ActivateBossThenNightMareLess75;
    }

    private void ActivateBossThenNightMareLess75()
    {
    Debug.Log("Уровень меньше 75");
    BossAttackActivated?.Invoke();
    }
}