using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField]
    private Box _box;
    [SerializeField] 
    private Vector2 _spawnRadius;
    [SerializeField]
    private float _secondsBetweenSpawn;

    private void Start()
    {
        StartCoroutine(SpawnerBox());
    }
    private IEnumerator SpawnerBox()
    {
        var _waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        while (true)
        {
            Instantiate(_box,
                    gameObject.transform.position + new Vector3(Random.Range(-_spawnRadius.x, _spawnRadius.x),
                                                            Random.Range(-_spawnRadius.y, _spawnRadius.y),
                                                            0),
                    Quaternion.identity,
                    gameObject.transform);

            yield return _waitForSeconds;
        }
    }

}
