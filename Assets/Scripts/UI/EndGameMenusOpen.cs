using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenusOpen : MonoBehaviour
{
    [SerializeField] private RestartMenu _restartMenu;
    [SerializeField] private WinMenu _winMenuEasy;
    [SerializeField] private WinMenu _winMenuNormal;
    [SerializeField] private WinMenu _winMenuHard;
    [SerializeField] private BossDeath _bossDeath;
    [SerializeField] private Cradle _cradle;

    private void OnEnable()
    {
        _bossDeath.AnimationEndedEasyLevel += _winMenuEasy.Open;
        _bossDeath.AnimationEndedNormalLevel += _winMenuNormal.Open;
        _bossDeath.AnimationEndedHardLevel += _winMenuHard.Open;
        _cradle.CradleDestroyed += _restartMenu.Open;
    }

    private void OnDisable()
    {
      _bossDeath.AnimationEndedEasyLevel -= _winMenuEasy.Open;
      _bossDeath.AnimationEndedNormalLevel -= _winMenuNormal.Open;
      _bossDeath.AnimationEndedHardLevel -= _winMenuHard.Open;
      _cradle.CradleDestroyed -= _restartMenu.Open;
    }
}
