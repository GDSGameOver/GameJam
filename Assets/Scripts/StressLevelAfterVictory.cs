using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressLevelAfterVictory : MonoBehaviour
{
    [SerializeField] private CountDownTimer _countDownTimer;
    [SerializeField] private CryTrigger _cryTrigger;
    [SerializeField] private Text _timerText;
    private float _stressAmountContainer;

    private void OnEnable()
    {
        _countDownTimer.StressTimeGetted += GetAfterVictoryStresLevel;
    }

    private void OnDisable()
    {
        _countDownTimer.StressTimeGetted -= GetAfterVictoryStresLevel;
    }



    private void GetAfterVictoryStresLevel()
    {
        _stressAmountContainer = _cryTrigger.GetStessLevel();
        _timerText.text = _stressAmountContainer.ToString();
    }
}