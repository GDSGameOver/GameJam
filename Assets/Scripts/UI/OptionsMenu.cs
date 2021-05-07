﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : Menu
{
    [SerializeField] private Toggle _controlJoystick;
    [SerializeField] private Toggle _controlFinger;
    [SerializeField] private Toggle _modeEasy;
    [SerializeField] private Toggle _modeNormal;
    [SerializeField] private Toggle _modeHard;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Image _background;

    private void Start()
    {
        CanvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(BackToMainMenu);
    }

    public override void Open()
    {
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1;
        _background.GetComponent<CanvasGroup>().alpha = 1;
        _mainMenuButton.interactable = true;
        Time.timeScale = 0;
    }

    public override void Close()
    {
        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.alpha = 0;
        _background.GetComponent<CanvasGroup>().alpha = 0;
        _mainMenuButton.interactable = false;
        Time.timeScale = 1;
        PlayerPrefs.SetInt("JoystickControl", _controlJoystick.isOn ? 1 : 0);
        PlayerPrefs.SetInt("FingerControl", _controlFinger.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Easy", _modeEasy.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Normal", _modeNormal.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Hard", _modeHard.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void BackToMainMenu()
    {
        AudioSource.Play();
        _mainMenu.Open();
        Close();
    }
}
