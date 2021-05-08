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

    [SerializeField] private AudioSource[] _babyCryes;
    [SerializeField] private Animator _animator;
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
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out Whill whill))
        {
            DamagedByWhill?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out BigSkull bigSkull))
        {
            DamagedByBigSkull?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out BossBody bossBody))
        {
            DamagedByBoss?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out FlySkull flySkull))
        {
            DamagedByFlySkull?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out FlyBone flyBone))
        {
            DamagedByFlyBone?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
    }

    private void Cry()
    {
        _babyCryes[Random.Range(0, 3)].Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BossBody bossBody))
        {
            DamagedByBoss?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
    }
}