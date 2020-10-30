using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cradle : MonoBehaviour
{
    public event UnityAction CradleDestroyed;

    public void EndGameTrigger()
    {
        CradleDestroyed?.Invoke();
    }
}
