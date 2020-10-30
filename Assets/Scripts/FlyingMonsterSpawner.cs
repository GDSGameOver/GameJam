using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonsterSpawner : MonoBehaviour
{
    [SerializeField] private VictoryMenu _victoryMenu;
    [SerializeField] private Transform[] _spawnPoints;  
    [SerializeField] private FlyingMonster _flyingMonster;
    [SerializeField] private float _minMonsterSpawnTime;
    [SerializeField] private float _maxMonsterSpawnTime;
    private float _elapsedTime;
    private float _randomMonsterSpawnTime;
    private FlyingMonster[] _flyingMonsters;

    private void OnEnable()
    {
        _victoryMenu.MenuOpened += ResetFlyingMonster;
    }

    private void OnDisable()
    {
        _victoryMenu.MenuOpened -= ResetFlyingMonster;
    }

    private void Start()
    {
        _flyingMonsters = FindObjectsOfType<FlyingMonster>();
        ResetFlyingMonster();
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
            Instantiate(_flyingMonster, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            _flyingMonsters = FindObjectsOfType<FlyingMonster>();
            _elapsedTime = 0;
        }
    }

    private void ResetFlyingMonster()
    {
        for (int i = 0; i < _flyingMonsters.Length; i++)
        {
            _flyingMonsters[i].gameObject.SetActive(false);
        }
    }
}
