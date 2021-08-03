using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : Menu
{
    [SerializeField] private GameObject[] _cradlesIcons;
    [SerializeField] private Button _buttonNext;
    [SerializeField] private Button _buttonPrevious;
    [SerializeField] private Button _buttonEquip;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _backToMainmenu;
    [SerializeField] private Image _background;
    private int _selectedCradle = 0;

    private void OnEnable()
    {
        
        _buttonEquip.onClick.AddListener(SaveCradle);
        _buttonNext.onClick.AddListener(NextCradle);
        _buttonPrevious.onClick.AddListener(PreviousCradle);
        _backToMainmenu.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _buttonEquip.onClick.AddListener(SaveCradle);
        _buttonNext.onClick.RemoveListener(NextCradle);
        _buttonPrevious.onClick.RemoveListener(PreviousCradle);
        _backToMainmenu.onClick.RemoveListener(Close);
    }

    private void NextCradle()
    {
        _cradlesIcons[_selectedCradle].gameObject.SetActive(false);
        _selectedCradle = (_selectedCradle + 1) % _cradlesIcons.Length;
        _cradlesIcons[_selectedCradle].gameObject.SetActive(true);
    }

    private void PreviousCradle()
    {
        _cradlesIcons[_selectedCradle].gameObject.SetActive(false);
        _selectedCradle--;
        if (_selectedCradle < 0)
        {
            _selectedCradle += _cradlesIcons.Length;
        }
        _cradlesIcons[_selectedCradle].gameObject.SetActive(true);
    }

    public void SaveCradle()
    {
        PlayerPrefs.SetInt("selectedCradle", _selectedCradle);
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
    }
}
