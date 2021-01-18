using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MonoBehaviour
{
    [SerializeField] private Transform[] _flyPoints;
    [SerializeField] private float _speed;
    private Vector3 _currentFlyPoint;
    private Animator _animator;
    private Collider2D _collider;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Idle");
        ChooseFlyPoint();
        transform.position = Vector3.MoveTowards(transform.position, _currentFlyPoint, _speed * Time.deltaTime);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000)), Vector2.zero);
        if (Input.GetMouseButton(0) && hit.collider == _collider)
        {
            _animator.SetTrigger("Death");
        }
        Fly();
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }

    private void Fly()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentFlyPoint, _speed * Time.deltaTime);
        if (transform.position == _currentFlyPoint)
        {
            ChooseFlyPoint();
        }
    }

    private void ChooseFlyPoint()
    {
        _currentFlyPoint = _flyPoints[Random.Range(0, _flyPoints.Length)].position;
    }

    public void Death()
    {
        _animator.SetTrigger("Death");
    }
}