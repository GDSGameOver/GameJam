using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBearBehavior : MonoBehaviour
{
    [SerializeField] private Boss _boss;
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
    [SerializeField] private FlyBone[] _flyBones;
    [SerializeField] private Animator _bossBearAnimator;

    [SerializeField] private BearBossSetting _setting;

    private bool _canAttack = true;
    private bool _bossReveal = false;
    private float _waitFlySkullTimeAttack;
    private float _waitClawTimeAttack;
    private float _waitBigSkullTimeAttack;

    private void OnEnable()
    {
        _boss.BossNighmareLevelEmpty += BossDie;
        _claw.PreparedToAttack += GetCradlePositionToAttackClaw;
        _bossAttackActivator.BossAttackActivated += ActivateBossAtack;
        _spine.Destroyed += BossHide;
    }

    private void OnDisable()
    {
        _boss.BossNighmareLevelEmpty -= BossDie;
        _claw.PreparedToAttack -= GetCradlePositionToAttackClaw;
        _bossAttackActivator.BossAttackActivated -= ActivateBossAtack;
        _spine.Destroyed -= BossHide;
    }

    private void Start()
    {
        var difficult = PlayerPrefs.GetInt("Difficult");

        _waitFlySkullTimeAttack = _setting.Setting[difficult].WaitBigSkullTimeAttack;
        _waitClawTimeAttack = _setting.Setting[difficult].WaitClawTimeAttack;
        _waitBigSkullTimeAttack = _setting.Setting[difficult].WaitBigSkullTimeAttack;

        for (int i = 0; i < _flyBones.Length; i++)
        {
            _flyBones[i].gameObject.SetActive(true);
        }
        _claw.gameObject.SetActive(true);
        for (int i = 0; i < _bigSkullAttacks.Length; i++)
        {
            _bigSkullAttacks[i].gameObject.SetActive(true);
        }

    }

    private void Update()
    {
        if (_canAttack == true && _bossReveal == false)
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
        var attackNumber = Random.Range(0, 13);
        switch (attackNumber)
        {
            case 0:
            case 1:
            case 2:
                BigSkullAttack(attackNumber);
                break;
            case 3:
            case 4:
            case 5:
                ClawAttack();
                break;
            case 6:
                FlySkullAttack(_flySkullsRight);
                break;
            case 7:
                FlySkullAttack(_flySkullsLeft);
                break;
            case 8:
                FlySkullAttack(_flySkullsUp);
                break;
            case 9:
                FlySkullAttack(_flySkullsDown);
                break;
            case 10:
                BoneWhillAttack(_boneWhillsLeft);
                break;
            case 11:
                BoneWhillAttack(_boneWhillsRight);
                break;
            case 12:
                BoneWhillAttack(_boneWhillsUp);
                break;
        }
    }

    private void ActivateBossAtack()
    {
        _bossReveal = true;
        _boss.SetBossPhase(true);
        StartCoroutine(WaitBossShow());
    }

    IEnumerator WaitBossShow()
    {
        yield return new WaitForSeconds(2);

        _bossBear.gameObject.SetActive(true);
        StartCoroutine(WaitToDropSpine());
    }

    private void BossHide()
    {
        _bossBearAnimator.SetTrigger("Hide");
        _canAttack = true;
        _boss.SetBossPhase(false);
        StartCoroutine(WaitBossHide());
    }

    IEnumerator WaitBossHide()
    {
        yield return new WaitForSeconds(1);
        _bossReveal = false;
    }

    private void BigSkullAttack(int index)
    {
        _bigSkullAttacks[index].gameObject.SetActive(true);
        _canAttack = false;
        _bigSkullAttacks[index].Reveal();
        WaitForAttackEnd(); 
    }

    private void WaitForAttackEnd()
    {
        StartCoroutine(WaitForSkullTimeAttack());
    }

    IEnumerator WaitForSkullTimeAttack()
    {
        yield return new WaitForSeconds(_waitBigSkullTimeAttack);
        _canAttack = true;
    }

    IEnumerator WaitForFlySkullTimeAttack()
    {
        yield return new WaitForSeconds(_waitFlySkullTimeAttack);
        _canAttack = true;
    }

    IEnumerator WaitForClawTimeAttack()
    {
        yield return new WaitForSeconds(_waitClawTimeAttack);
        _canAttack = true;
    }

    private void FlySkullAttack(FlySkull[] skulls)
    {
        _canAttack = false;
        for (int i = 0; i < skulls.Length; i++)
        {
            skulls[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForFlySkullTimeAttack());
    }

    private void BoneWhillAttack(Whill[] whills)
    {
        _canAttack = false;
        for (int i = 0; i < whills.Length; i++)
        {
            whills[i].gameObject.SetActive(true);
        }
        StartCoroutine(WaitForSkullTimeAttack());
    }

    /*
    private void BossReveal()
    {
        if (_bossReveal == true)
        {
           _bossBear.gameObject.SetActive(true);
            StartCoroutine(WaitToDropSpine());
        } 
    }
    */
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


    /*
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
    }/*/

    private void DisableObjects(FlySkull[] skulls)
    {
        for (int i = 0; i < skulls.Length; i++)
        {
            skulls[i].gameObject.SetActive(true);
        }
    }

    private void DisableObjects(Whill[] whills)
    {
        for (int i = 0; i < whills.Length; i++)
        {
            whills[i].gameObject.SetActive(true);
        }
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
        for (int i = 0; i < _flyBones.Length; i++)
        {
            _flyBones[i].gameObject.SetActive(false);
        }

        DisableObjects(_boneWhillsRight);
        DisableObjects(_boneWhillsLeft);
        DisableObjects(_boneWhillsUp);
        DisableObjects(_flySkullsRight);
        DisableObjects(_flySkullsLeft);
        DisableObjects(_flySkullsUp);
        DisableObjects(_flySkullsDown);
        enabled = false;

        _bossDeath.gameObject.SetActive(true);
    }
}
