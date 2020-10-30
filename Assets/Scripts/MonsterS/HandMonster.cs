using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HandMonster : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private Animator _animator;

    void Start()
    {
        gameObject.transform.SetParent(_transform);
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Idle");
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }
}
