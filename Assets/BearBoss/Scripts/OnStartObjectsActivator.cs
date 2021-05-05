using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartObjectsActivator : MonoBehaviour
{
    [SerializeField] private BossBearBehavior _boss;
    
    private void Activate()
    {
        _boss.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
