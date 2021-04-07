using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _move;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void Update()
    {
        _move.x = _joystick.Horizontal;
        _move.y = _joystick.Vertical;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _move*_speed*Time.fixedDeltaTime);
    }
}
