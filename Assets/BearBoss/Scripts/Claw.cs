using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Claw : MonoBehaviour
{
    public event UnityAction PreparedToAttack;

    [SerializeField] private AudioSource _attackSound;
    private Animator _animator;
    private Collider2D _collider;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    public void Attack()
    {
        _animator.SetTrigger("Reveal");
    }

    public void PrepareToAttack()
    {
        PreparedToAttack?.Invoke();
        _animator.SetTrigger("Idle");
    }

    private void PlayAttackSound()
    {
        _attackSound.Play();
    }

}
