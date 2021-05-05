using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossDeath : MonoBehaviour
{
    public event UnityAction AnimationEnded;

    private void BossDissapear()
    {
        AnimationEnded?.Invoke();
    }
}
