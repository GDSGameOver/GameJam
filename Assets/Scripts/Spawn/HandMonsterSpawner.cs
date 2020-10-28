using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMonsterSpawner : MonoBehaviour, IMonsterSpawner
{
    [SerializeField] private HandMonster _handMonster;
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
            Instantiate(_handMonster, transform.position, Quaternion.identity);
            _elapsedTime = 0;
        }
    }
}
