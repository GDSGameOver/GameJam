using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealSetting", menuName = "Settings/HealSetting", order = 1)]
public class HealSetting : ScriptableObject
{
    public float[] Heal => _heal;
    [SerializeField] private float[] _heal = new float[3];
}

