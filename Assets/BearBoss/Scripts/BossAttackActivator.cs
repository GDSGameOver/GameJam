using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossAttackActivator : MonoBehaviour
{
    public event UnityAction BossAttackActivated;

    [SerializeField] Boss _boss;

    private void OnEnable()
    {
        _boss.NightMareLevelWentdownLess75 += ActivateBossThenNightMareLess75;
        _boss.NightMareLevelWentdownLess50 += ActivateBossThenNightMareLess50;
        _boss.NightMareLevelWentdownLess25 += ActivateBossThenNightMareLess25;
    }

    private void OnDisable()
    {
        _boss.NightMareLevelWentdownLess75 -= ActivateBossThenNightMareLess75;
        _boss.NightMareLevelWentdownLess50 -= ActivateBossThenNightMareLess50;
        _boss.NightMareLevelWentdownLess25 -= ActivateBossThenNightMareLess25;
    }

    private void ActivateBossThenNightMareLess75()
    {
        //Debug.Log("Уровень меньше 75");
        BossAttackActivated?.Invoke();
    }

    private void ActivateBossThenNightMareLess50()
    {
        //Debug.Log("Уровень меньше 50");
        //BossAttackActivated?.Invoke();
    }

    private void ActivateBossThenNightMareLess25()
    {
        //Debug.Log("Уровень меньше 25");
        BossAttackActivated?.Invoke();
    }
}