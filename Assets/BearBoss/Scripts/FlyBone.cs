using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBone : MonoBehaviour
{
    [SerializeField] private Transform[] _flyPoints;
    [SerializeField] private Transform[] _startPoints;
    [SerializeField] private float _speed;
    private Transform _currentFlyPoint;
    private Collider2D _collider;
    private Animator _animator;

    void Start()
    {
        _speed = 5;
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _currentFlyPoint = _startPoints[Random.Range(0, _startPoints.Length)];
        transform.position = Vector3.MoveTowards(transform.position, _currentFlyPoint.position, _speed * Time.deltaTime);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000)), Vector2.zero);
        if (Input.GetMouseButton(0) && hit.collider == _collider)
        {
            _animator.SetTrigger("Crush");
            
        }
        Fly();
        transform.position = Vector3.MoveTowards(transform.position, _currentFlyPoint.position, _speed * Time.deltaTime);
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

    public void ResetFlybone()
    {
        transform.position = _startPoints[Random.Range(0, _startPoints.Length)].position;
    }
}
