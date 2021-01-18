using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private FlyingMonster[] _flyingMonsters;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _flyingMonsters = FindObjectsOfType<FlyingMonster>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Ultrasound");
            for (int i = 0; i < _flyingMonsters.Length; i++)
            {
                _flyingMonsters[i].Death();
            }
        }
    }
}
