using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBear : MonoBehaviour
{
    [SerializeField] private Spine _spine;
    [SerializeField] private AudioSource _revealSound;
    [SerializeField] private AudioSource[] _attackSound;
    [SerializeField] private AudioSource _hideSound;
    [SerializeField] private AudioSource _handsRevealSound;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Reset()
    {
        gameObject.SetActive(false);
    }

    private void ActivateSpine()
    {
        _spine.gameObject.SetActive(true);
    }

    private void ActivateHandsAttack()
    {
        _animator.SetTrigger("Attack");
    }

    private void PlayAttackSound()
    {
        _attackSound[Random.Range(0, 1)].Play();
    }

    private void PlayRevealSound()
    {
        _revealSound.Play();
    }

    private void PlayHideSound()
    {
        _hideSound.Play();
    }

    private void PlayHandsRevealSound()
    {
        _handsRevealSound.Play();
    }
}
