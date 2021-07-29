using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BossIcon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    public event UnityAction<bool> Using;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _animator.SetTrigger("Damaged");
        Using?.Invoke(true); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Using?.Invoke(false);
        RecieveDamageCountdown();
    }

    private void RecieveDamageCountdown()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        enabled = false;
        yield return new WaitForSeconds(1);
        enabled = true;
    }
}
