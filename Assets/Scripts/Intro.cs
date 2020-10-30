using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
   [SerializeField] MenuBackGround _menuBackGround;
   [SerializeField] MainMenu _mainMenu;

   public void OpenMainMenu()
   {
        _mainMenu.Open();
        _menuBackGround.gameObject.SetActive(true);
        gameObject.SetActive(false);
   }
}
