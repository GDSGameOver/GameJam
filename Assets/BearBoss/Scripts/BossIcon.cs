using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BossIcon : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction Using;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _animator.SetTrigger("Damaged");
        Using?.Invoke();
    }
}
