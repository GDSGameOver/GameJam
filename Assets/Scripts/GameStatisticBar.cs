using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatisticBar : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false;
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
    }
}
