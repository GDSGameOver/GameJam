﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class Cradle : MonoBehaviour, IDragHandler
{
    public event UnityAction CradleDestroyed;
    public event UnityAction<float> HPChangedNormalized;

    public event UnityAction DamagedByClaw;
    public event UnityAction DamagedByWhill;
    public event UnityAction DamagedByBigSkull;
    public event UnityAction DamagedByBoss;
    public event UnityAction DamagedByFlySkull;
    public event UnityAction DamagedByFlyBone;

    [SerializeField] private Inputs _inputs;
    [SerializeField] private HealSetting _healSetting;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _cradleCrouchSound;
    [SerializeField] private AudioClip[] _babyCryes;

    [SerializeField] private Animator _animator;
    private RectTransform _rectTransform;

    private float _hp = 100;
    private float _hpMax = 100;
    private float _heal;

    private Vector3 _lastPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();    
    }

    private void Start()
    {
        _heal = _healSetting.Heal[PlayerPrefs.GetInt("Difficult")];
    }

    public void EndGameTrigger()
    {
        CradleDestroyed?.Invoke();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void Update()
    {
        if (_inputs.CanPlayerHeal)
            Heal(_heal * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            Heal(_heal * Time.deltaTime);
            //_hp -= 50;
            //TakeDamage(0);
        }
    }

    public void Heal(float count)
    {
        _animator.SetTrigger("Swing");
       // _audioSource.PlayOneShot(_cradleCrouchSound);
        _hp += count;
        if (_hp > _hpMax)
            _hp = _hpMax;
        HPChangedNormalized?.Invoke(_hp / _hpMax);
    }

    public void TakeDamage(float damage)
    {
        if (_hp < 0)
            return;

        _hp -= damage;
        if (_hp <= 0)
        {
            _hp = 0;
            StartCoroutine(OnDead());
        }

        HPChangedNormalized?.Invoke(_hp / _hpMax);
        _animator.SetTrigger("Damaged");
       // Cry();
    }

    private IEnumerator OnDead()
    {
        yield return new WaitForSeconds(1);
        CradleDestroyed?.Invoke();
        _animator.SetTrigger("Death");

    }


    private void Cry()
    {
        _audioSource.PlayOneShot(_babyCryes[Random.Range(0, _babyCryes.Length)]);
    }


    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta*1.4f;
    }

   

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Claw claw))
        {
            DamagedByClaw?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out Whill whill))
        {
            DamagedByWhill?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out BigSkull bigSkull))
        {
            DamagedByBigSkull?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out BossBody bossBody))
        {
            DamagedByBoss?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out FlySkull flySkull))
        {
            DamagedByFlySkull?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
        if (collision.gameObject.TryGetComponent(out FlyBone flyBone))
        {
            DamagedByFlyBone?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
    }
    */


    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BossBody bossBody))
        {
            DamagedByBoss?.Invoke();
            _animator.SetTrigger("Damaged");
            Cry();
        }
    }
    */
}