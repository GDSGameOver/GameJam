using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossDeath : MonoBehaviour
{
    public event UnityAction AnimationEndedEasyLevel;
    public event UnityAction AnimationEndedNormalLevel;
    public event UnityAction AnimationEndedHardLevel;

    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private AudioSource _burnSound;
    [SerializeField] private AudioSource _handCrackSound;
    [SerializeField] private AudioSource _faceCrackSound;
    [SerializeField] private AudioSource _bossExplotionSound;
    private bool _modeEasy = false;
    private bool _modeNormal = false;
    private bool _modeHard = false;

    private void Start()
    {
        _modeEasy = PlayerPrefs.GetInt("Easy") == 1;
        _modeNormal = PlayerPrefs.GetInt("Normal") == 1;
        _modeHard = PlayerPrefs.GetInt("Hard") == 1;
    }

    private void BossDissapear()
    {
        if (_modeEasy)
        {
            AnimationEndedEasyLevel?.Invoke();
        }
        if (_modeNormal)
        {
            AnimationEndedNormalLevel?.Invoke();
        }
        if (_modeHard)
        {
            AnimationEndedHardLevel?.Invoke();
        }
        
    }

    private void DieRoar()
    {
        _dieSound.Play();
    }

    private void PlayCrackHandSound()
    {
        _handCrackSound.Play();
    }

    private void PlayBurnSound()
    {
       _burnSound.Play();
    }

    private void PlayFaceCrackSound()
    {
        _faceCrackSound.Play();
    }

    private void PlayBossExplosionSound()
    {
        _bossExplotionSound.Play();
    }
}
