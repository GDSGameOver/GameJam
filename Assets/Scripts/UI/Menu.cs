using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected AudioSource AudioSource;

    public abstract void Open();

    public abstract void Close();

    
  
}
