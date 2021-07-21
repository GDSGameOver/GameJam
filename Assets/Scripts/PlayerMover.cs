using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _move;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Image _iconJoystic;

    private void Update()
    {
        _move.x = _joystick.Horizontal;
        _move.y = _joystick.Vertical;
        _rigidbody2D.MovePosition(_rigidbody2D.position + _move * _speed * Time.deltaTime);
    } 
}
