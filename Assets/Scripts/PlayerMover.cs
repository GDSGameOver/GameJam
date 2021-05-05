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
    [SerializeField] private Button _iconBoss;

    private void Update()
    {
        _move.x = _joystick.Horizontal;
        _move.y = _joystick.Vertical;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPos.x==_iconJoystic.transform.position.x)
            {
                _iconBoss.enabled = false;
            }
            else
            {
                _iconBoss.enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _move*_speed*Time.fixedDeltaTime);
    }

   
}
