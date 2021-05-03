using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyBone : MonoBehaviour
{
    [SerializeField] private Transform[] _flyPoints;
    [SerializeField] private Transform[] _startPoints;
    [SerializeField] private float _speed;
    [SerializeField] private Button _hitButton; 
    private Transform _currentFlyPoint;
    private Collider2D _collider;
    private Animator _animator;

    private void OnEnable()
    {
        _hitButton.onClick.AddListener(ResetFlybone);
    }

    private void OnDisable()
    {
        _hitButton.onClick.RemoveListener(ResetFlybone);
    }

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
        _animator.SetTrigger("Crush");
        StartCoroutine(WaitForBoneDestroy());
    }

    IEnumerator WaitForBoneDestroy()
    {
        yield return new WaitForSeconds(.5f);
        transform.position = _startPoints[Random.Range(0, _startPoints.Length)].position;
    }
}
