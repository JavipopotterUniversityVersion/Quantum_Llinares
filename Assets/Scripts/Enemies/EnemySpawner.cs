using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Vector2 _spawnRateRange;
    [SerializeField] Vector2Int _enemiesAmountRange;
    [SerializeField] Vector2 _positionRange;
    [SerializeField] Vector2 _speedRange;
    [SerializeField] GameObject _enemyPrefab;

    [SerializeField] PlayerTracker _playerTracker;
    [SerializeField] ShipTransition _shipTransition;

    [SerializeField] AnimationCurve _spawnRateCurve;
    [SerializeField] AnimationCurve _speedCurve;
    [SerializeField] float _timeToReachMaxScale = 500.0f;
    [SerializeField] Transform _entitesContainer;

    float _timer = 0.0f;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_positionRange.x * 2, _positionRange.y * 2, 0));
    }

    private void Update() {
        _timer += Time.deltaTime;
    }

    public void Restart()
    {
        StopCoroutine(SpawnEnemies());
        _timer = 0.0f;
    }

    [ContextMenu("Start Spawning")]
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnRate = Random.Range(_spawnRateRange.x, _spawnRateRange.y) * _spawnRateCurve.Evaluate(_timer / _timeToReachMaxScale);
            yield return new WaitForSeconds(spawnRate);

            for(int i = 0; i < Random.Range(_enemiesAmountRange.x, _enemiesAmountRange.y); i++) SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        bool isVertical = Random.Range(0, 2) == 0;
        Vector2 spawnPosition;

        if(isVertical)
        {
            bool isLeft = Random.Range(0, 2) == 0;

            if(isLeft) spawnPosition = new Vector2(-_positionRange.x, Random.Range(-_positionRange.y, _positionRange.y));
            else spawnPosition = new Vector2(_positionRange.x, Random.Range(-_positionRange.y, _positionRange.y));
        }
        else
        {
            bool isTop = Random.Range(0, 2) == 0;

            if(isTop) spawnPosition = new Vector2(Random.Range(-_positionRange.x, _positionRange.x), _positionRange.y);
            else spawnPosition = new Vector2(Random.Range(-_positionRange.x, _positionRange.x), -_positionRange.y);
        }

        spawnPosition += (Vector2)transform.position;

        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, _entitesContainer);

        if(enemy.TryGetComponent(out FollowMovement followMovement))
        {
            followMovement.setTarget(_playerTracker.GetNearestPlayer(spawnPosition));
            followMovement.setSpeed(Random.Range(_speedRange.x, _speedRange.y) * _speedCurve.Evaluate(_timer / _timeToReachMaxScale));
        }

        if(enemy.TryGetComponent(out ShipTransitionListener shipTransitionListener))
        {
            shipTransitionListener.setShipTransition(_shipTransition);
            shipTransitionListener.setPlayerTracker(_playerTracker);
        }
    }
}
