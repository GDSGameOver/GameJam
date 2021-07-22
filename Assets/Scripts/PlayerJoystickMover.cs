using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerJoystickMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _move;

    private void Update()
    {
        _move.x = _joystick.Horizontal;
        _move.y = _joystick.Vertical;
        _rigidbody2D.MovePosition(_rigidbody2D.position + _move * _speed * Time.deltaTime);
    }
}
