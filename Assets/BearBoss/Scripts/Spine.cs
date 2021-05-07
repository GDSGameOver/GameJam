using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spine : MonoBehaviour
{
    public event UnityAction TouchedToBossIcon;
    public event UnityAction Destroyed;

    [SerializeField] private Transform _pointToMove;
    [SerializeField] private float _speed;
    [SerializeField] private int _numberOfHits;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Button _buttonSpineDestroy;
    private Animator _animator;

    private void OnEnable()
    {
        _buttonSpineDestroy.onClick.AddListener(HitSpine);
    }

    private void OnDisable()
    {
        _buttonSpineDestroy.onClick.RemoveListener(HitSpine);
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointToMove.position, _speed * Time.deltaTime);
    }

    public void TriggerToHideBoss()
    {
        Destroyed?.Invoke();
        _numberOfHits = 0;
        transform.position = _startPoint.position;
        gameObject.SetActive(false);
    }

    private void HitSpine()
    {
        _numberOfHits++;
        _animator.SetTrigger("Hit");
        if (_numberOfHits > 15)
        {
            _animator.SetTrigger("Death");
        }
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BossIcon bossIcon))
        {
            TouchedToBossIcon?.Invoke();
        }
    }
    
}
