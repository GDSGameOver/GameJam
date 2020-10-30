using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMonsterSpawner : MonoBehaviour, IMonsterSpawner
{
    [SerializeField] private VictoryMenu _victoryMenu;
    [SerializeField] private HandMonster _handMonster;
    [SerializeField] private float _minMonsterSpawnTime;
    [SerializeField] private float _maxMonsterSpawnTime;
    [SerializeField] private Transform _transform;
    private float _elapsedTime;
    private float _randomMonsterSpawnTime;
    private HandMonster[] _handMonsters;

    private void OnEnable()
    {
        _victoryMenu.MenuOpened += ResetHandMonster;
    }

    private void OnDisable()
    {
        _victoryMenu.MenuOpened -= ResetHandMonster;
    }


    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        _elapsedTime += Time.deltaTime;
        _randomMonsterSpawnTime = Random.Range(_minMonsterSpawnTime, _maxMonsterSpawnTime);
        if (_elapsedTime > _randomMonsterSpawnTime)
        {
            Instantiate(_handMonster, transform.position, Quaternion.identity);
            _handMonsters = FindObjectsOfType<HandMonster>();
            _elapsedTime = 0;
        }
    }

    private void ResetHandMonster()
    {
        for (int i = 0; i < _handMonsters.Length; i++)
        {
            _handMonsters[i].gameObject.SetActive(false);
        }
    }
}
