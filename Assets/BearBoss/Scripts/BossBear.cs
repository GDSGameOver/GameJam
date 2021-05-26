using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBear : MonoBehaviour
{
    [SerializeField] private Spine _spine;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _revealSound;
    [SerializeField] private AudioClip[] _attackSound;
    [SerializeField] private AudioClip _hideSound;
    [SerializeField] private AudioClip _handsRevealSound;

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
        _audioSource.PlayOneShot(_attackSound[Random.Range(0, _attackSound.Length)]);
    }

    private void PlayRevealSound()
    {
        _audioSource.PlayOneShot(_revealSound);
    }

    private void PlayHideSound()
    {
        _audioSource.PlayOneShot(_hideSound);
    }

    private void PlayHandsRevealSound()
    {
        _audioSource.PlayOneShot(_handsRevealSound);
    }
}
