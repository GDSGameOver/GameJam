using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : Menu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _rulesButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private RulesMenu _rulesMenu;
    [SerializeField] private MenuBackGround _menuBackGround;

    public event UnityAction PlayButtonPressed;


    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
        _rulesButton.onClick.AddListener(OpenRulesMenu);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(StartGame);
        _rulesButton.onClick.RemoveListener(OpenRulesMenu);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    public void StartGame()
    {
        _menuBackGround.gameObject.SetActive(false);
        PlayButtonPressed?.Invoke();
        Close();
    }

    private void OpenRulesMenu()
    {
        Close();
        _rulesMenu.Open();
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public override  void Open()
    {
        CanvasGroup.alpha = 1;
        _rulesButton.interactable = true;
        _playButton.interactable = true;
        _exitButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.blocksRaycasts = false;
        _rulesButton.interactable = false;
        _playButton.interactable = false;
        _exitButton.interactable = false;
    }
}
