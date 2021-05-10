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
}
