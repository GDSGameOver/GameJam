using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private DifficultDamage _difficultDamage;

    [SerializeField] private AudioSource _attackSound;


    private float _damage;

    private void Awake()
    {        
        _damage = _difficultDamage.Damage[PlayerPrefs.GetInt("Difficult")];
    }

    private void PlayAttackSound()
    {
        _attackSound.Play();
    }

    public void CradleTakeDamage(Cradle cradle)
    {
        cradle.TakeDamage(_damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Cradle cradle))
        {
            CradleTakeDamage(cradle);
        }
    }
}
