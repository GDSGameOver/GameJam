using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossSetting _bossSetting;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _painSound;

    private float _hp = 100;
    private float _hpMax = 100;
    private float _lastHP;
    private float _heal;
    private float _damage;
    private bool isBossPhase;

    private float elapsedTime = 0;

    public event UnityAction NightMareLevelWentdownLess75;
    public event UnityAction NightMareLevelWentdownLess50;
    public event UnityAction NightMareLevelWentdownLess25;
    public event UnityAction BossNighmareLevelEmpty;

    public event UnityAction<float> HPChangedNormalized;

    private void Start()
    {
        _heal = _bossSetting.Setting[PlayerPrefs.GetInt("Difficult", 0)].IncreaseNightmareValueByTime;
        _damage = _bossSetting.Setting[PlayerPrefs.GetInt("Difficult", 0)].ReduceNighmareByHit;
    }

    public void TakeDamage()
    {
        if (_hp <= 0)
            return;

        _lastHP = _hp;
        var damage = _damage;
        if (isBossPhase)
            damage *= 0.1f;
        _hp -= damage;

        
        if (_hp <= 75 && _lastHP > 75)
        {
            NightMareLevelWentdownLess75?.Invoke();
        }
        
        if (_hp <= 50 && _lastHP > 50)
        {
             NightMareLevelWentdownLess50?.Invoke();

        }

        if (_hp <= 25 && _lastHP > 25)
        {
            NightMareLevelWentdownLess25?.Invoke();
        }
        if (_hp <= 0)
        {
            BossNighmareLevelEmpty?.Invoke();
        }

        _audioSource.PlayOneShot(_painSound[Random.Range(0, _painSound.Length)]);
        HPChangedNormalized?.Invoke(_hp / _hpMax);
    }

    public void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1)
        {
            elapsedTime--;
            Heal();
        }
    }

    public void Heal()
    {
        _hp += _heal;
        if (_hp > _hpMax)
            _hp = _hpMax;
        _lastHP = _hp;
        HPChangedNormalized?.Invoke(_hp / _hpMax);
    }

    public void SetBossPhase(bool isActive)
    {
        isBossPhase = isActive;
    }
}

/*
 _increaseNightmareValueBySpine = 2; // лечение босса от хребта
 _increaseFearValueByTime = 1; // ущерб по времени

 _increaseNightmareValueByTime = 0; // авто лечение босса по времени?
 _reduceNighmareByHit = 3; // ущерб по боссу при клике по иконке?


 _reduceFearBySwing = 20; // лечение от качания

 */
