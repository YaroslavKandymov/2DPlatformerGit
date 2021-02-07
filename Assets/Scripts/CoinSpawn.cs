using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Transform _money;
    [SerializeField] private Coin _coin;
    [SerializeField] private int _coinCount;

    private Transform[] _points;
    private int _rnd;
    private List<int> _numberPoints;
    
    private void Start()
    {
        _points = new Transform[_money.childCount];

        _numberPoints = new List<int>();

        for (int i = 0; i < _money.childCount; i++)
        {
            _points[i] = _money.GetChild(i);
        }

        for (int i = 0; i < _coinCount; i++)
        {
            _rnd = Random.Range(0, _money.childCount);
            if (_numberPoints.Contains(_rnd))
            {
                i--;
            }
            else
            {
                _numberPoints.Add(_rnd);
                Instantiate(_coin, _points[_rnd].position, Quaternion.identity);
            }
        }
    }
}
