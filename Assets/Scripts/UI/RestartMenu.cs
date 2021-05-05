using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartMenu : Menu
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Image _background;

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(BackToMainMenu);
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(BackToMainMenu);
        _restartButton.onClick.RemoveListener(RestartGame);
    }

    public override void Close()
    {
        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.alpha = 0;
        _background.GetComponent<CanvasGroup>().alpha = 0;
        _mainMenuButton.interactable = false;
        _restartButton.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1;
        _background.GetComponent<CanvasGroup>().alpha = 1;
        _mainMenuButton.interactable = true;
        _restartButton.interactable = true;
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("BearBoss");
    }
}
