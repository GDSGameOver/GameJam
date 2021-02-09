using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySkull : MonoBehaviour
{
    [SerializeField] private Transform _flyPoint;
    [SerializeField] private float _speed;
    private Collider2D _collider;
    private Animator _animator;

    void Start()
    {
        _speed = 5;
        _animator = GetComponent<Animator>();
        transform.position = Vector3.MoveTowards(transform.position, _flyPoint.position, _speed * Time.deltaTime);
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _flyPoint.position, _speed * Time.deltaTime);
    }
}
