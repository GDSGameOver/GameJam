using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBone : MonoBehaviour
{
    [SerializeField] private Transform[] _flyPoints;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _currentFlyPoint;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        transform.position = Vector3.MoveTowards(transform.position, _currentFlyPoint.position, _speed * Time.deltaTime);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentFlyPoint.position, _speed * Time.deltaTime);
        Fly();
    }

    private void Fly()
    {
        if (transform.position == _currentFlyPoint.position)
        {
            ChooseFlyPoint();
        }
    }

    private void ChooseFlyPoint()
    {
        _currentFlyPoint.position = _flyPoints[Random.Range(0, _flyPoints.Length)].position;
    }

    public void Death()
    {
        _animator.SetTrigger("Death");
    }
}
