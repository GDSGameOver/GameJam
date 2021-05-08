using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigSkull : MonoBehaviour
{
    public event UnityAction AttackEnded;

    [SerializeField] private AudioSource _attackSound;
    [SerializeField] private AudioSource _revealSound;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Reveal()
    {
        _animator.SetTrigger("Attack");
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }

    private void PlayAttackSound()
    {
        _attackSound.Play();
    }

    private void PlayRevealSound()
    {
        _revealSound.Play();
    }
}
