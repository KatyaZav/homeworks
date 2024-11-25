using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private EnemySpawner[] _enemySpawners;

    void Start()
    {
        _spawner.Init();

        foreach (var spawner in _enemySpawners)
        {
            spawner.Init();
        }
    }
}
