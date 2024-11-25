using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _spawner;
    [SerializeField] private EnemySpawner[] _enemySpawners;
    [SerializeField] private GameSettings _gameSettings;

    void Start()
    {
        _spawner.Init();

        foreach (var spawner in _enemySpawners)
        {
            spawner.Init();
        }

        _gameSettings.Init();
    }
}
