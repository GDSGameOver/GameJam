using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spine : MonoBehaviour
{
    public event UnityAction TouchedToBossIcon;
    public event UnityAction Destroyed;

    [SerializeField] private Transform _pointToMove;
    [SerializeField] private float _speed;
    [SerializeField] private int _numberOfHits;
    private Animator _animator;
    private Collider2D _collider;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointToMove.position, _speed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000)), Vector2.zero);
        if (_numberOfHits>15)
        {
            _animator.SetTrigger("Death");
        }
        if (Input.GetMouseButton(0) && hit.collider == _collider)
        {
            _animator.SetTrigger("Hit");
        }
    }

    public void HitsCount()
    {
        _numberOfHits++;
        Debug.Log(_numberOfHits);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out NightmareBearIcon nightmareBearIcon))
        {
            TouchedToBossIcon?.Invoke();
        }
    }

    public void TriggerToHideBoss()
    {
        Destroyed?.Invoke();
        gameObject.SetActive(false);
    }
    
}
