using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    [SerializeField] private Image _background;

    public override void Open()
    {
        AudioSource.Play();
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1;
        _background.GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 0;
    }

    public override void Close()
    {
        AudioSource.Play();
        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.alpha = 0;
        _background.GetComponent<CanvasGroup>().alpha = 0;
        Time.timeScale = 1;
    }

   
}
