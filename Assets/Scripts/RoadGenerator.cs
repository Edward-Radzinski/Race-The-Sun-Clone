using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Road[] _roadPref;

    private PoolMono<Road>[] _pools;
    [SerializeField] private float _roadLength;
    [SerializeField] private List<Road> _roads = new List<Road>();

    private void Start()
    {
        _poolCount = _roadPref.Length;
        _pools = new PoolMono<Road>[_poolCount];
        for (int i = 0; i < _poolCount; i++)
        {
            _pools[i] = new PoolMono<Road>(_roadPref[i], _poolCount, this.transform);
            _pools[i].autoExpand = _autoExpand;
        }
        while(_roads.Count < 10)
        {
            CreateRoad(Random.Range(0, _poolCount));
        }
    }

    private void Update()
    {
        if (_roads.Count < 10)
        {
            CreateRoad(Random.Range(0, _poolCount));
        }

        if (Ship.Instance.transform.position.z - _roads[0].gameObject.transform.position.z > _roadLength / 2)
        {
            _roads[0].gameObject.SetActive(false);
            _roads.RemoveAt(0);
        } 
    }

    private void CreateRoad(int rand)
    {
        var road = _pools[rand].GetFreeElement();
        var position = _roads.Count > 0 ? _roads[_roads.Count - 1].transform.position.z + _roadLength : 0 + _roadLength;
        road.transform.position = new Vector3(0, 0, position);
        _roads.Add(road);
    }
}
