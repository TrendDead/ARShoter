using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Enemy[] _enemies;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy());
    }

    private IEnumerator SpawnRandomEnemy()
    {
        var _waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        while (true)
        {
            Enemy newEnemy = Instantiate(_enemies[Random.RandomRange(0, _enemies.Length)], RandomPlaceInSphere(_spawnRadius), Quaternion.identity);

            Vector3 loocDir = _target.transform.position + newEnemy.transform.position;
            newEnemy.transform.rotation = Quaternion.LookRotation(loocDir);

            newEnemy.Dying += OnEnemyDying;

            yield return _waitForSeconds;
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _target.AddScore();
    }
    private Vector3 RandomPlaceInSphere(float radius)
    {
        return Random.insideUnitSphere * radius;
    }
}
