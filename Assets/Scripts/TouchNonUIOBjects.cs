using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TouchNonUIOBjects : MonoBehaviour
{
    [SerializeField] private Collider2D _controlCollider;
    [SerializeField] private GameObject _movingObject;


    private float _deltaX, _deltaY, _offSetPositionX, _offSetPositionY;
    private Rigidbody2D _rigibody2D;
    private bool _moveAllowed = false;

    public event UnityAction<bool> Using;

    private void Awake()
    {
        _offSetPositionX = _controlCollider.offset.x;
        _offSetPositionY = _controlCollider.offset.y;
    }

    private void Start()
    {        
        _rigibody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        _movingObject.transform.position = transform.position;
        _controlCollider.offset = new Vector2(_offSetPositionX, _offSetPositionY);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (_controlCollider == Physics2D.OverlapPoint(touchPos))
                    {
                        _deltaX = touchPos.x - transform.position.x;
                        _deltaY = touchPos.y - transform.position.y;
                        _moveAllowed = true;
                        _rigibody2D.velocity = new Vector2(0, 0);
                    }
                    break;

                case TouchPhase.Moved:
                    if (_controlCollider == Physics2D.OverlapPoint(touchPos) && _moveAllowed)
                        _rigibody2D.MovePosition(new Vector2(touchPos.x - _deltaX, touchPos.y - _deltaY));
                    Using?.Invoke(true);
                
                    break;

                case TouchPhase.Ended:
                    _moveAllowed = false;
                    Using?.Invoke(false);
                  
                    break;
            }
        }
    }
}
