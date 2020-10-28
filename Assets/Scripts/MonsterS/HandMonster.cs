using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HandMonster : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Idle");
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }
}
