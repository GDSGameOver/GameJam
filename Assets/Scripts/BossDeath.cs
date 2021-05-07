using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossDeath : MonoBehaviour
{
    public event UnityAction AnimationEnded;

    [SerializeField] private AudioSource _dieSound;

    private void BossDissapear()
    {
        AnimationEnded?.Invoke();
    }

    private void DieRoar()
    {
        _dieSound.Play();
    }
}
