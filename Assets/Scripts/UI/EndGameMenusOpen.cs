using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenusOpen : MonoBehaviour
{
    [SerializeField] private RestartMenu _restartMenu;
    [SerializeField] private WinMenu _winMenu;
    [SerializeField] private BossDeath _bossDeath;
    [SerializeField] private Cradle _cradle;

    private void OnEnable()
    {
        _bossDeath.AnimationEnded += _winMenu.Open;
        _cradle.CradleDestroyed += _restartMenu.Open;
    }

    private void OnDisable()
    {
      _bossDeath.AnimationEnded -= _winMenu.Open;
        _cradle.CradleDestroyed -= _restartMenu.Open;
    }
}
