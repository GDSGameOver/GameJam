using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlySkull : MonoBehaviour
{
    public event UnityAction FlyedToPoint;

    [SerializeField] private Transform _flyPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource _attackSound;

    void Start()
    {
        _speed = 5;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _flyPoint.position, _speed * Time.deltaTime);
        if (transform.position.x == _flyPoint.position.x)
        {
            FlyedToPoint?.Invoke();
            transform.position = _startPoint.position;
            gameObject.SetActive(false);
        }
    }

    private void PlayAttackSound()
    {
        _attackSound.Play();
    }
}
