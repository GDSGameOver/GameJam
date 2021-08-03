using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviour
{

    [SerializeField] private Cradle[] _cradles;
    [SerializeField] private Transform _spawnPoint;


    private void Start()
    {
        int selectedCradle = PlayerPrefs.GetInt("selectedCradle");
        Cradle cradle = Instantiate(_cradles[selectedCradle], _spawnPoint.position, Quaternion.identity);
    }

    
    private void Update()
    {
        
    }
}
