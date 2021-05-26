using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FearByTimeSetting", menuName = "Settings/FearByTimeSetting", order = 1)]
public class FearByTimeSetting : ScriptableObject
{
    public float[] Values => _values;
    [SerializeField] private float[] _values = new float[3];
}

