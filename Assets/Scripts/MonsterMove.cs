using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _startPosition;
    private float _speed;
    Animator _animator;

    private void Start()
    {
        StartCoroutine(Reveal());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    IEnumerator Reveal()
    {
        _speed = 0;
        yield return new WaitForSecondsRealtime(2);
        _speed = .5f;
    }
    
}
