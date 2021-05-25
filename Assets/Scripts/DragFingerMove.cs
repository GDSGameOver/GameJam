using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 _touchPosition;
    private Rigidbody2D _rigidBody;
    private Vector3 _direction;
    private float _moveSpeed = 50f;
    [SerializeField] private Collider2D _controlCollider;

    
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            _touchPosition.z = 0;
            if (_controlCollider==Physics2D.OverlapPoint(_touchPosition))
            {
                _direction = (_touchPosition - transform.position);
                _rigidBody.velocity = new Vector2(_direction.x, _direction.y) * _moveSpeed;
            }
            if (touch.phase == TouchPhase.Ended)
                _rigidBody.velocity = Vector2.zero;
        }
    }
}

