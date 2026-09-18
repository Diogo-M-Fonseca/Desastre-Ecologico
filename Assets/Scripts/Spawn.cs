using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private Vector2 spawnBreaks;
    [SerializeField] private GameObject[] prefab;

    private float _timer;
    private float _value;
    private Transform _lastTransform;
    private Transform _readd;
    void Update()
    {
        foreach (var item in spawnPoints)
        {
            if (item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
            }
        }

        _readd = _lastTransform ? _lastTransform : null;

        if (_timer == 0.0f)
            _value = Random.Range(spawnBreaks.x, spawnBreaks.y);

        _timer += Time.deltaTime;

        if (_timer >= _value && spawnPoints.Count > 1)
        {
            _lastTransform = spawnPoints[Random.Range(0, spawnPoints.Count)];
            if (_readd) spawnPoints.Add(_readd);
            Instantiate(prefab[Random.Range(0, prefab.Length)], _lastTransform);
            spawnPoints.Remove(_lastTransform);
            _timer = 0.0f;
        }
        else if (_timer >= _value && spawnPoints.Count==1)
        {
            Instantiate(prefab[Random.Range(0, prefab.Length)], spawnPoints[0]);
            _timer = 0.0f;
        }

        spawnBreaks = spawnBreaks * 0.9999f;
    }
}