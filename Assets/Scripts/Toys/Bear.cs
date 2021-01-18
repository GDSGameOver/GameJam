using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    private CryTrigger _cryTrigger;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("RestoreFear");
            ReduceFear();
        }
    }

    private void ReduceFear()
    {
        _cryTrigger = FindObjectOfType<CryTrigger>();
        _cryTrigger.IncreaseValueInSliderByBear();
    }
}
