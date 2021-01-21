using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cradle : MonoBehaviour
{
    public event UnityAction CradleDestroyed;
    public event UnityAction DamagedByClaw;
    private Vector3 _position;

    public void EndGameTrigger()
    {
        CradleDestroyed?.Invoke();
    }

    public Vector3 GetPosition()
    {
        _position = transform.position;
        return _position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Claw claw))
        {
            DamagedByClaw?.Invoke();
        }
    }
}
