using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VictoryMenu : Menu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _rulesButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private RulesMenu _rulesMenu;
    [SerializeField] private Image _background;

    public event UnityAction MenuOpened;
 
    public event UnityAction TryAgainButtonPressed;

    private void Start()
    {
        CanvasGroup.blocksRaycasts = false;
    }


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

    private void StartGame()
    {
        AudioSource.Play();
        TryAgainButtonPressed?.Invoke();
        Close();
    }

    private void OpenRulesMenu()
    {
        Close();
        _rulesMenu.Open();
    }

    private void ExitGame()
    {
        AudioSource.Play();
        Application.Quit();
    }

    public override void Open()
    {
        MenuOpened?.Invoke();
        CanvasGroup.alpha = 1;
        _background.GetComponent<CanvasGroup>().alpha = 1;
        CanvasGroup.blocksRaycasts = true;
        _rulesButton.interactable = true;
        _playButton.interactable = true;
        _exitButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _background.GetComponent<CanvasGroup>().alpha = 0;
        _rulesButton.interactable = false;
        _playButton.interactable = false;
        _exitButton.interactable = false;
    }

    
}
