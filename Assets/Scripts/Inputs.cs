using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public bool CanDamaging => _inputUsing == false && _cradleUsing == false;
    public bool CanPlayerHeal => _inputUsing == false && _cradleUsing == true;

    [SerializeField] private TouchNonUIOBjects _touchInput;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private CradleButtonSwing _cradleButtonSwing;

    private bool _inputUsing;
    private bool _cradleUsing;

    private void OnEnable()
    {
        _touchInput.Using += InputUsing;
        _joystick.Using += InputUsing;
        _cradleButtonSwing.Using += CradleUsing;
    }

    private void OnDisable()
    {
        _touchInput.Using -= InputUsing;
        _joystick.Using -= InputUsing;
        _cradleButtonSwing.Using -= CradleUsing;
    }

    private void InputUsing(bool active)
    {
        _inputUsing = active;
    }

    private void CradleUsing(bool active)
    {
        _cradleUsing = active;
    }
}
