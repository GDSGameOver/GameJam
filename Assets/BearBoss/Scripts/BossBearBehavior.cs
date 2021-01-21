using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBearBehavior : MonoBehaviour
{
    [SerializeField] private Cradle _cradle;
    [SerializeField] private Claw _claw;
    private Vector3 _positionToAttackCradle;
    int _numberOfAttacks;
    private void OnEnable()
    {
        _claw.PreparedToAttack += GetCradlePositionToAttackClaw;
    }

    private void OnDisable()
    {
        _claw.PreparedToAttack -= GetCradlePositionToAttackClaw;
    }

    private void Start()
    {
      _numberOfAttacks = Random.Range(1, 21);
    }

   
    private void Update()
    {
        ClawAttack(_numberOfAttacks);
    }

    private void ClawAttack(int numberOfAttacks)
    {
        for (int i = 0; i < numberOfAttacks; i++)
        {
            _claw.Attack();
        }
    }

    private void GetCradlePositionToAttackClaw()
    {
        _claw.transform.position = _cradle.GetPosition();
    }
}
