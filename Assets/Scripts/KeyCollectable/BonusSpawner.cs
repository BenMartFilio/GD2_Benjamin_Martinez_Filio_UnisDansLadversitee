using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bonusPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    private int _spawnPointIndex = 0;
    private List<int> _listOfIndex = new List<int>();
    private int _whichSpawn = 0;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _listOfIndex.Add(i);
        }
    }

    private void OnEnable()
    {
        PlayerCollect.OnKeyCollected += SpawnNewBonus;
    }

    private void OnDisable()
    {
        PlayerCollect.OnKeyCollected -= SpawnNewBonus;
    }

    private void SpawnNewBonus()
    {
        if (_spawnPointIndex >= _spawnPoints.Length)
        {
            return;
        }
        _whichSpawn = _listOfIndex[Random.Range(0, _listOfIndex.Count)];
        Instantiate(_bonusPrefab, _spawnPoints[_whichSpawn].position, _spawnPoints[_whichSpawn].rotation);
        _listOfIndex.Remove(_whichSpawn);
        
        _spawnPointIndex++;

    }
}
