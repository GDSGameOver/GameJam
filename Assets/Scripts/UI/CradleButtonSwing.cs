using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CradleButtonSwing : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction<bool> Using;

    public void OnPointerDown(PointerEventData eventData)
    {
        Using?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Using?.Invoke(false);
    }
}
