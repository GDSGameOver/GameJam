using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenuInGame : Menu
{
    [SerializeField] private Toggle _modeEasy;
    [SerializeField] private Toggle _modeNormal;
    [SerializeField] private Toggle _modeHard;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Image _background;
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSfx;

    private void Start()
    {
        _sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume");
        _sliderSfx.value =  PlayerPrefs.GetFloat("SfxVolume");
        CanvasGroup.blocksRaycasts = false;

        var difficult = PlayerPrefs.GetInt("Difficult");
 
        if (difficult == 0)
        {
            _modeEasy.isOn = true;
        }
        if (difficult == 1)
        {
            _modeNormal.isOn = true;
        }
        if (difficult == 2)
        {
            _modeHard.isOn = true;
        }

      //  _modeEasy.enabled = false;
      //  _modeNormal.enabled = false;
       // _modeHard.enabled = false;
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
    }

    private void BackToMainMenu()
    {
        AudioSource.Play();
        Close();
    }

    public void ChangeSound(float volume)
    {
        _audioMixer.audioMixer.SetFloat("BearBossSfx", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }

    public void ChangeMusic(float volume)
    {
        _audioMixer.audioMixer.SetFloat("BearBossMusic", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

}
