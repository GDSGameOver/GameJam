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

    private void Start()
    {
        var difficult = PlayerPrefs.GetInt("Difficult");
        Debug.Log(difficult);
    }

    private void BossDissapear(int difficult)
    {
        
        if (difficult == 0)
        {
            AnimationEndedEasyLevel?.Invoke();
        }
        if (difficult == 1)
        {
            AnimationEndedNormalLevel?.Invoke();
        }
        if (difficult == 2)
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
