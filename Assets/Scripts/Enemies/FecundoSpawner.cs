using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecundoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _fecundo, _EntitiesContainer;

    [SerializeField] private float _spawnRadius = 20.0f;

    private void Start()
    {
        Vector2 direction = new Vector2(Random.Range(-1 * _spawnRadius, 1 * _spawnRadius), Random.Range(-1 * _spawnRadius, 1 * _spawnRadius));

        Transform fecundoTransform = Instantiate(_fecundo, direction, Quaternion.identity).GetComponent<Transform>();
        fecundoTransform.parent = _EntitiesContainer.transform;
        
    }
}
