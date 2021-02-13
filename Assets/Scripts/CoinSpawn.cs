using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Transform _money;
    [SerializeField] private Coin _coin;
    [SerializeField] private int _coinCount;

    private Transform[] _points;
    private int _random;
    private List<int> _numberPoints;

    private void Start()
    {
        _points = new Transform[_money.childCount];

        _numberPoints = new List<int>();

        for (int i = 0; i < _money.childCount; i++)
        {
            _points[i] = _money.GetChild(i);
        }

        GenerateRandomPoints();
        SpawnCoins();
    }

    private void GenerateRandomPoints()
    {
        while (_numberPoints.Count < _coinCount)
        {
            _random = CreateRandomNumber(_money.childCount);
            if (_numberPoints.Contains(_random))
            {
                _random = CreateRandomNumber(_money.childCount);
            }
            else
            {
                _numberPoints.Add(_random);
            }
        }
    }

    private void SpawnCoins()
    {
        foreach (var point in _numberPoints)
        {
            Instantiate(_coin, _points[point].position, Quaternion.identity);
        }
    }

    private int CreateRandomNumber(int maxNumber)
    {
        return Random.Range(0, maxNumber);
    }
}
