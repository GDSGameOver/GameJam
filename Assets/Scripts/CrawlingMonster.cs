using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingMonster : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _speed;

    private void Start()
    {
        StartCoroutine(Reveal());
    }

    private void Update()
    {
        Move();
    }

    IEnumerator Reveal()
    {
        _speed = 0;
        yield return new WaitForSecondsRealtime(2);
        _speed = .5f;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
