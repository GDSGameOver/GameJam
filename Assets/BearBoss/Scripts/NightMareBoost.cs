using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMareBoost : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spine spine))
        {
            _animator.SetTrigger("BoostReveal");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spine spine))
        {
            _animator.SetTrigger("BoostOff");
        }
    }
}
