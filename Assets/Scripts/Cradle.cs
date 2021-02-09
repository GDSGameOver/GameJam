using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cradle : MonoBehaviour
{
    public event UnityAction CradleDestroyed;
    public event UnityAction DamagedByClaw;
    public event UnityAction DamagedByWhill;
    public event UnityAction DamagedByBigSkull;
    public event UnityAction DamagedByBoss;
    public event UnityAction DamagedByFlySkull;
    public event UnityAction DamagedByFlyBone;


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
        if (collision.gameObject.TryGetComponent(out Whill whill))
        {
            DamagedByWhill?.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out BigSkull bigSkull))
        {
            DamagedByBigSkull?.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out BossBody bossBody))
        {
            DamagedByBoss?.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out FlySkull flySkull))
        {
            DamagedByFlySkull?.Invoke();
        }
        if (collision.gameObject.TryGetComponent(out FlyBone flyBone))
        {
            DamagedByFlyBone?.Invoke();
        }
    }
}
