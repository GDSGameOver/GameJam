using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BossIcon : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction Using;

    public void OnPointerDown(PointerEventData eventData)
    {
        Using?.Invoke();
    }
}
