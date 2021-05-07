using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _rulesButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private RulesMenu _rulesMenu;
    [SerializeField] private OptionsMenu _optionsMenu;


    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
        _rulesButton.onClick.AddListener(OpenRulesMenu);
        _optionsButton.onClick.AddListener(OpenOptionsMenu);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(StartGame);
        _rulesButton.onClick.RemoveListener(OpenRulesMenu);
        _optionsButton.onClick.RemoveListener(OpenOptionsMenu);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    public void StartGame()
    {
        AudioSource.Play();
        SceneManager.LoadScene("BearBoss");
    }

    private void OpenRulesMenu()
    {
        AudioSource.Play();
        Close();
        _rulesMenu.Open();
    }

    private void OpenOptionsMenu()
    {

        AudioSource.Play();
        _optionsMenu.Open();
    }

    private void ExitGame()
    {
        AudioSource.Play();
        Application.Quit();
    }

    public override void Open()
    {
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1;
        _rulesButton.interactable = true;
        _optionsButton.interactable = true;
        _playButton.interactable = true;
        _exitButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.blocksRaycasts = false;
        _optionsButton.interactable = false;
        _rulesButton.interactable = false;
        _playButton.interactable = false;
        _exitButton.interactable = false;
    }

    
}
