using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _upgradesPrefabs;

    [SerializeField] Vector2[] _upgradePos;

    [SerializeField] Transform entitiesContainer;

    [SerializeField] float _upgradespawnRate = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawnUpgrades());
    }
    public void SpawnUpgrade()
    {
        bool isVertical = Random.Range(0, 2) == 0;
        Vector2 spawnPosition = _upgradePos[Random.Range(0, _upgradePos.Length)];
        GameObject _upgrades;
        if (spawnPosition.y < 0)
        {
            _upgrades = Instantiate(_upgradesPrefabs[Random.Range(0, _upgradesPrefabs.Length)], spawnPosition, Quaternion.identity);
        }
        else
        {
            _upgrades = Instantiate(_upgradesPrefabs[Random.Range(0, _upgradesPrefabs.Length)], spawnPosition, new Quaternion(0,0,180,1));
        }

        _upgrades.transform.SetParent(entitiesContainer);
    }
    IEnumerator SpawnUpgrades()
    {

        while (true)
        {
            // print("entro");
            yield return new WaitForSeconds(_upgradespawnRate);
            // print("termino de esperar");
            SpawnUpgrade();

        }
    }

}
