using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerJoystickMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Image _background;
    [SerializeField] private Image _handle;

    private Vector2 _move;

    private void Update()
    {
        JoystickMove();
    }

    private void JoystickMove()
    {
        bool joystickIsOn = PlayerPrefs.GetInt("JoystickControl") == 1;
        if (joystickIsOn)
        {
            _background.raycastTarget = true;
            _handle.raycastTarget = true;
            _joystick.enabled=true;
            _move.x = _joystick.Horizontal;
            _move.y = _joystick.Vertical;
            _rigidbody2D.MovePosition(_rigidbody2D.position + _move * _speed * Time.deltaTime);
        }
        else
        {
            _background.raycastTarget = false;
            _handle.raycastTarget = false;
            _joystick.enabled = false;
        }
    }
}
