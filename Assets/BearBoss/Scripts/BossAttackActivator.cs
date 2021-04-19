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
        _sliderBehavior.NightMareLevelWentdownLess75 += ActivateBossThenNightMareLess50;
        _sliderBehavior.NightMareLevelWentdownLess75 += ActivateBossThenNightMareLess25;
    }

    private void OnDisable()
    {
        _sliderBehavior.NightMareLevelWentdownLess75 -= ActivateBossThenNightMareLess75;
        _sliderBehavior.NightMareLevelWentdownLess75 -= ActivateBossThenNightMareLess50;
        _sliderBehavior.NightMareLevelWentdownLess75 -= ActivateBossThenNightMareLess25;
    }

    private void ActivateBossThenNightMareLess75()
    {
    Debug.Log("Уровень меньше 75");
    BossAttackActivated?.Invoke();
    }

    private void ActivateBossThenNightMareLess50()
    {
        Debug.Log("Уровень меньше 50");
        BossAttackActivated?.Invoke();
    }

    private void ActivateBossThenNightMareLess25()
    {
        Debug.Log("Уровень меньше 25");
        BossAttackActivated?.Invoke();
    }
}