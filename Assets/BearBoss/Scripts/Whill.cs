using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whill : MonoBehaviour
{
    [SerializeField] private AudioSource _attackSound;

    private void PlayAttackSound()
    {
        _attackSound.Play();
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }
}
