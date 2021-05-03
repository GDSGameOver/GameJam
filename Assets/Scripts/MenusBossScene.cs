using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusBossScene : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private Button _options;
    [SerializeField] private Button _backToGameFromPause;
    [SerializeField] private Button _backToGameFromOptions;
    [SerializeField] private OptionsMenuInGame _optionsMenu;
    [SerializeField] private PauseMenu _pauseMenu;


    private void OnEnable()
    {
        _pause.onClick.AddListener(_pauseMenu.Open);
        _backToGameFromPause.onClick.AddListener(_pauseMenu.Close);
        _options.onClick.AddListener(_optionsMenu.Open);
        _backToGameFromOptions.onClick.AddListener(_optionsMenu.Close);
    }

    private void OnDisable()
    {
        _pause.onClick.AddListener(_pauseMenu.Open);
        _backToGameFromPause.onClick.RemoveListener(_pauseMenu.Close);
        _options.onClick.RemoveListener(_optionsMenu.Open);
        _backToGameFromOptions.onClick.RemoveListener(_optionsMenu.Close);
    }   
}
