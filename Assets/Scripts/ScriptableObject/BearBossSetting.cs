using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BearBoss", menuName = "Settings/BearBoss", order = 1)]
public class BearBossSetting : ScriptableObject
{
    public BearBossDifficultSetting[] Setting => _setting;
    [SerializeField] private BearBossDifficultSetting[] _setting = new BearBossDifficultSetting[3];
}

[System.Serializable]
public struct BearBossDifficultSetting
{
    public float WaitFlySkullTimeAttack;
    public float WaitClawTimeAttack;
    public float WaitBigSkullTimeAttack;
}