using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBearBehavior : MonoBehaviour
{
    [SerializeField] private Cradle _cradle;
    [SerializeField] private Claw _claw;
    [SerializeField] private BigSkull[] _bigSkullAttacks;
    [SerializeField] private Whill[] _boneWhills;
    [SerializeField] private FlySkull[] _flySkulls;
    [SerializeField] private Transform[] _pointsOfFlySkullsLeft;
    [SerializeField] private Transform[] _pointsOfFlySkullsRight;
    [SerializeField] private Transform[] _pointsOfFlySkullsUp;
    [SerializeField] private Transform[] _pointsOfFlySkullsDown;
    [SerializeField] private Transform[] _pointsOfFlyBones;
    [SerializeField] private BossBear _bossBear;
    [SerializeField] private Spawner _spawnerOfAttacks;
    [SerializeField] private Transform[] _flyBonesStartPoints;
    private FlyBone[] _flyBones;
    private int _attackNumber;
    private bool _canAttack = true;

    private Vector3 _positionToAttackCradle;
    int _numberOfClawAttacks = 5;

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
        _flyBones = FindObjectsOfType<FlyBone>();
    }

   
    private void Update()
    {
       // ResetFlyBone();
        if (_canAttack == true)
        {
            BossRandonAttack();
        }
      //  ClawAttack(_numberOfClawAttacks);
        
    }

    private void ClawAttack()
    {
        _canAttack = false;
        _claw.Attack();
        StartCoroutine(WaitForClawTimeAttack());
    }

    private void GetCradlePositionToAttackClaw()
    {
        _claw.transform.position = _cradle.GetPosition();
    }

    

    private void BossRandonAttack()
    {
        _attackNumber = Random.Range(0, 6);
        if (_attackNumber == 0 || _attackNumber == 1 || _attackNumber == 2)
        {
            BigSkullAttack();
        }
        if (_attackNumber == 3 || _attackNumber == 4 || _attackNumber == 5)
        {
            ClawAttack();
        }
       
    }

    private void BigSkullAttack()
    {
        _bigSkullAttacks[_attackNumber].gameObject.SetActive(true);
        _canAttack = false;
        _bigSkullAttacks[_attackNumber].Reveal();
        WaitForAttackEnd();
    }


    private void WaitForAttackEnd()
    {
        StartCoroutine(WaitForSkullTimeAttack());
    }

    IEnumerator WaitForSkullTimeAttack()
    {
        yield return new WaitForSeconds(4);
        _canAttack = true;
    }
    IEnumerator WaitForClawTimeAttack()
    {
        yield return new WaitForSeconds(2);
        _canAttack = true;
    }

    private void ResetFlyBone()
    {
        if (_flyBones.Length<4)
        {
            foreach (var flyBone in _flyBones)
            {
                if (flyBone.enabled == false)
                {
                    flyBone.transform.position = _flyBonesStartPoints[Random.Range(0, _flyBonesStartPoints.Length)].position;
                    flyBone.enabled = true;
                }
            }
        }
           
    }
    
    private void FlySkullRightAttack()
    {

    }
    private void FlySkullLeftAttack()
    {

    }

    private void FlySkullUpAttack()
    {

    }

    private void FlySkullDownAttack()
    {

    }

    private void BossReveal()
    {

    }
    private void BoneWhillAttackLeft()
    {

    }
    private void BoneWhillAttackRight()
    {

    }
    private void BoneWhillAttackDown()
    {

    }

    private void BoneWhillAttackUp()
    {

    }
}
