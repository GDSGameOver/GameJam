using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] GameOverMenu _gameOverScreen;
    [SerializeField] GameplayComponents _gameplayComponents;
    [SerializeField] Cradle _cradle;
    [SerializeField] MainMenu _mainMenu;
    [SerializeField] VictoryMenu _victoryMenu;
    [SerializeField] MenuBackGround _menuBackGround;
    [SerializeField] CountDownTimer _timer;
    [SerializeField] GameStatisticBar _gameStatisticBar;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        _cradle.CradleDestroyed += OpenGameOverScreen;
        _victoryMenu.TryAgainButtonPressed += StartGame;
        _timer.WinConditionCompleted += OpenVictoryMenu;
    }

    private void OnDisable()
    {
        _cradle.CradleDestroyed -= OpenGameOverScreen;
        _victoryMenu.TryAgainButtonPressed -= StartGame;
        _timer.WinConditionCompleted -= OpenVictoryMenu;
    }

    private void OpenMainMenu()
    {
        _mainMenu.Open();
        _menuBackGround.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        _gameplayComponents.gameObject.SetActive(true);
        _victoryMenu.Close();
        _gameStatisticBar.Open();
    }

    private void OpenVictoryMenu()
    {
        _gameplayComponents.gameObject.SetActive(false);
        _gameStatisticBar.Close();
        _victoryMenu.Open();
    }

    private void OpenGameOverScreen()
    {
        _gameOverScreen.gameObject.SetActive(true);
    }
}
