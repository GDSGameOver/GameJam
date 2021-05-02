using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossBearBehavior : MonoBehaviour
{
    public event UnityAction BossDied;

    [SerializeField] private BossAttackActivator _bossAttackActivator;
    [SerializeField] private Cradle _cradle;
    [SerializeField] private Claw _claw;
    [SerializeField] private Spine _spine;
    [SerializeField] private BossDeath _bossDeath;
    [SerializeField] private BigSkull[] _bigSkullAttacks;
    [SerializeField] private Whill[] _boneWhillsRight;
    [SerializeField] private Whill[] _boneWhillsLeft;
    [SerializeField] private Whill[] _boneWhillsUp;
    [SerializeField] private FlySkull[] _flySkullsRight;
    [SerializeField] private FlySkull[] _flySkullsLeft;
    [SerializeField] private FlySkull[] _flySkullsUp;
    [SerializeField] private FlySkull[] _flySkullsDown;
    [SerializeField] private Transform[] _pointsOfFlyBones;
    [SerializeField] private BossBear _bossBear;
    [SerializeField] private Transform[] _flyBonesStartPoints;
    [SerializeField] private SliderBehavior _sliderBehavior;
    private FlyBone[] _flyBones;
    private int _attackNumber;
    private bool _canAttack = true;
    private bool _bossReveal = false; 


    private void OnEnable()
    {
        _sliderBehavior.BossNighmareLevelEmpty += BossDie;
        _claw.PreparedToAttack += GetCradlePositionToAttackClaw;
        _bossAttackActivator.BossAttackActivated += ActivateBossAtack;
        _spine.Destroyed += BossHide;
    }

    private void OnDisable()
    {
        _sliderBehavior.BossNighmareLevelEmpty -= BossDie;
        _claw.PreparedToAttack -= GetCradlePositionToAttackClaw;
        _bossAttackActivator.BossAttackActivated -= ActivateBossAtack;
        _spine.Destroyed -= BossHide;
    }

    private void Start()
    {
        _flyBones = FindObjectsOfType<FlyBone>();
    }

   
    private void Update()
    {
        if (_canAttack == true)
        {
            BossRandomAttack();
        }
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

    private void BossRandomAttack()
    {
        _attackNumber = Random.Range(0, 13);
        switch (_attackNumber)
        {
            case 0:
                BigSkullAttack();
                break;
            case 1:
                BigSkullAttack();
                break;
            case 2:
                BigSkullAttack();
                break;
            case 3:
                ClawAttack();
                break;
            case 4:
                ClawAttack();
                break;
            case 5:
                ClawAttack();
                break;
            case 6:
                FlySkullRightAttack();
                break;
            case 7:
                FlySkullLeftAttack();
                break;
            case 8:
                FlySkullUpAttack();
                break;
            case 9:
                FlySkullDownAttack();
                break;
            case 10:
                BoneWhillAttackLeft();
                break;
            case 11:
                BoneWhillAttackRight();
                break;
            case 12:
                BoneWhillAttackUp();
                break;
        }
    }

    private void ActivateBossAtack()
    {
        _bossReveal = true;
    }

    private void BossHide()
    {
        _bossReveal = false;
        _canAttack = true;
        _bossBear.gameObject.SetActive(false);
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
        BossReveal();
        if (_bossReveal == false)
        {
            _canAttack = true;
        }
    }

    IEnumerator WaitForFlySkullTimeAttack()
    {
        yield return new WaitForSeconds(6);
        BossReveal();
        if (_bossReveal == false)
        {
            _canAttack = true;
        }
    }

    IEnumerator WaitForClawTimeAttack()
    {
        yield return new WaitForSeconds(2);
        BossReveal();
        if (_bossReveal == false)
        {
            _canAttack = true;
        }
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
        _canAttack = false;
        for (int i = 0; i < _flySkullsRight.Length; i++)
        {
            _flySkullsRight[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForFlySkullTimeAttack());
    }

    private void FlySkullLeftAttack()
    {
        _canAttack = false;
        for (int i = 0; i < _flySkullsLeft.Length; i++)
        {
            _flySkullsLeft[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForFlySkullTimeAttack());
    }

    private void FlySkullUpAttack()
    {
        _canAttack = false;
        for (int i = 0; i < _flySkullsUp.Length; i++)
        {
            _flySkullsUp[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForFlySkullTimeAttack());
    }

    private void FlySkullDownAttack()
    {
        _canAttack = false;
        for (int i = 0; i < _flySkullsDown.Length; i++)
        {
            _flySkullsDown[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForFlySkullTimeAttack());
    }

    private void BossReveal()
    {
        if (_bossReveal == true)
        {
           _bossBear.gameObject.SetActive(true);
            StartCoroutine(WaitToDropSpine());
        } 
    }

    private void BossDeath()
    {
        if (_bossReveal == true)
        {
            _bossReveal = false;
            _bossBear.gameObject.SetActive(true);
        }
    }

    IEnumerator WaitToDropSpine()
    {
        yield return new WaitForSeconds(3);
        _spine.gameObject.SetActive(true);
    }

    private void BoneWhillAttackLeft()
    {
        _canAttack = false;
        for (int i = 0; i < _boneWhillsLeft.Length; i++)
        {
            _boneWhillsLeft[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForSkullTimeAttack());
    }

    private void BoneWhillAttackRight()
    {
        _canAttack = false;
        for (int i = 0; i < _boneWhillsRight.Length; i++)
        {
            _boneWhillsRight[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForSkullTimeAttack());
    }
 
    private void BoneWhillAttackUp()
    {
        _canAttack = false;
        for (int i = 0; i < _boneWhillsUp.Length; i++)
        {
            _boneWhillsUp[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForSkullTimeAttack());
    }

    private void BossDie()
    {
        _cradle.gameObject.SetActive(false);
        _bossBear.gameObject.SetActive(false);
        _claw.gameObject.SetActive(false);
        _spine.gameObject.SetActive(false);
        for (int i = 0; i < _bigSkullAttacks.Length; i++)
        {
            _bigSkullAttacks[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _bigSkullAttacks.Length; i++)
        {
            _bigSkullAttacks[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _boneWhillsRight.Length; i++)
        {
            _boneWhillsRight[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _boneWhillsLeft.Length; i++)
        {
            _boneWhillsLeft[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _boneWhillsUp.Length; i++)
        {
            _boneWhillsUp[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _boneWhillsUp.Length; i++)
        {
            _boneWhillsUp[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _boneWhillsUp.Length; i++)
        {
            _boneWhillsUp[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _boneWhillsUp.Length; i++)
        {
            _boneWhillsUp[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _flySkullsRight.Length; i++)
        {
            _flySkullsRight[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _flySkullsRight.Length; i++)
        {
            _flySkullsRight[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _flySkullsLeft.Length; i++)
        {
            _flySkullsLeft[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _flySkullsUp.Length; i++)
        {
            _flySkullsUp[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _flySkullsDown.Length; i++)
        {
            _flySkullsDown[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _flyBones.Length; i++)
        {
            _flyBones[i].gameObject.SetActive(false);
        }
        BossDied?.Invoke();
    }
}
