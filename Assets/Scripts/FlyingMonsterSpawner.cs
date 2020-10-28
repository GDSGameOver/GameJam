using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonsterSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;  
    [SerializeField] private FlyingMonster _flyingMonster;
    [SerializeField] private float _minMonsterSpawnTime;
    [SerializeField] private float _maxMonsterSpawnTime;
    private float _elapsedTime;
    private float _randomMonsterSpawnTime;

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
            _elapsedTime = 0;
        }
    }
}
