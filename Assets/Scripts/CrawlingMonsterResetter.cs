using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingMonsterResetter : MonoBehaviour
{
    [SerializeField] private VictoryMenu _victoryMenu;
    private CrawlingMonster[] _crawlingMonsters;

    private void Start()
    {
        ResetCrawlingMonster();
    }

    private void Update()
    {
        _crawlingMonsters = FindObjectsOfType<CrawlingMonster>();
    }

    private void OnEnable()
    {
        _victoryMenu.MenuOpened += ResetCrawlingMonster;
    }

    private void OnDisable()
    {
        _victoryMenu.MenuOpened -= ResetCrawlingMonster;
    }

    private void ResetCrawlingMonster()
    {
        for (int i = 0; i < _crawlingMonsters.Length; i++)
        {
            _crawlingMonsters[i].gameObject.SetActive(false);
        }
    }
}
