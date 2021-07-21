using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyBone : Enemy
{
    [SerializeField] private Transform[] _flyPoints;
    [SerializeField] private Transform[] _startPoints;
    [SerializeField] private AudioSource _crushSound;
    [SerializeField] private float _speed;
    [SerializeField] private Button _hitButton; 
    private Transform _currentFlyPoint;
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
        _animator = GetComponent<Animator>();
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

    private void ResetFlybone()
    {
        _crushSound.Play();
        _animator.SetTrigger("Crush"); 
    }

    private void ReturnToStartPosition()
    {
        StartCoroutine(WaitToActivate());
    }

    IEnumerator WaitToActivate()
    {
        gameObject.transform.position = _startPoints[Random.Range(0, _startPoints.Length)].position;
        _speed = 0;
        yield return new WaitForSeconds(5);
        _speed = 2.5f;
    }
}
