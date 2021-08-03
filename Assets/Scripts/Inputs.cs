using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public bool CanDamaging => _inputUsing == false && _cradleButtonUsing == false;
    public bool CanPlayerHeal => _inputUsing == false && _cradleButtonUsing == true && _bossIconHit == false;

    [SerializeField] private BossIcon _bossIcon;
    [SerializeField] private Cradle[] _cradle;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private CradleButtonSwing _cradleButtonSwing;

    private bool _inputUsing;
    private bool _cradleButtonUsing;
    private bool _bossIconHit;
    private Cradle _selectedCradle;

    private void OnEnable()
    {
        _selectedCradle = _cradle[PlayerPrefs.GetInt("selectedCradle")];
        _selectedCradle.gameObject.SetActive(true);
        _bossIcon.Using += BossHitting;
        _selectedCradle.Using += InputUsing;
        _joystick.Using += InputUsing;
        _cradleButtonSwing.Using += CradleUsing;
    }

    private void OnDisable()
    {
        _bossIcon.Using -= BossHitting;
        _selectedCradle.Using -= InputUsing;
        _joystick.Using -= InputUsing;
        _cradleButtonSwing.Using -= CradleUsing;
    }

    private void InputUsing(bool active)
    {
        _inputUsing = active;
    }

    private void CradleUsing(bool active)
    {
        _cradleButtonUsing = active;
    }

    private void BossHitting(bool active)
    {
        _bossIconHit = active;
    }

}
