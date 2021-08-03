using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whill : Enemy
{

    [SerializeField] private Transform _pointToPrepareAttack;
    [SerializeField] private Transform _pointToAttack;
    [SerializeField] private Transform _pointToReset;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _rotateMoveSpeed;
    [SerializeField] private float _rotateAttackSpeed;


    private void Reset()
    {
        transform.position = _pointToReset.position;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Attack(_pointToAttack.position, _pointToPrepareAttack.position, _moveSpeed, _rotateMoveSpeed, 
               _attackSpeed, _rotateAttackSpeed);
    }

    private void Attack(Vector3 pointToAttack, Vector3 pointToPrepareAttack, float moveSpeed, float rotateMoveSpeed, 
                       float attackSpeed, float rotateAttackSpeed)
    {
        Move(pointToPrepareAttack, moveSpeed, rotateMoveSpeed);
        if (transform.position.y <= pointToPrepareAttack.y)
        {
            Move(pointToAttack, attackSpeed, rotateAttackSpeed);
        }
        if (transform.position == pointToAttack)
        {
            Reset(); 
        }
    }

    private void Move(Vector3 pointToMove, float moveSpeed, float rotateSpeed)
    {
        transform.position = Vector3.MoveTowards(transform.position, pointToMove, moveSpeed * Time.deltaTime);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
