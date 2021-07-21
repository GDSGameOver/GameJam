using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossSetting", menuName = "Settings/BossSetting", order = 1)]
public class BossSetting : ScriptableObject
{
    public BossDifficultSetting[] Setting => _setting;
    [SerializeField] private BossDifficultSetting[] _setting = new BossDifficultSetting[3];
}

[System.Serializable]
public struct BossDifficultSetting
{
    public float IncreaseNightmareValueByTime;
    public float ReduceNighmareByHit;
    public float IncreaseNightmareValueBySpine;
}