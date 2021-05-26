using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultDamage", menuName = "Difficult/DifficultDamage", order = 1)]
public class DifficultDamage : ScriptableObject
{
    public float[] Damage => _damage;
    [SerializeField] private float[] _damage = new float[3];
}
