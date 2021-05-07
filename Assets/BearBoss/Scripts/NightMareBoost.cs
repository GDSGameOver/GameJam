using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMareBoost : MonoBehaviour
{
    [SerializeField] private AudioSource _nighmareBoostSound;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spine spine))
        {
            _nighmareBoostSound.Play();
            _animator.SetTrigger("BoostReveal");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spine spine))
        {
            _nighmareBoostSound.Stop();
            _animator.SetTrigger("BoostOff");
        }
    }
}
