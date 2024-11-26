using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private EnemySpawner[] _enemySpawners;
    [SerializeField] private GameSettings _gameSettings;

    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private PlayerConfig _playerConfig;

    void Start()
    {
        InputHandler input = new InputHandler();
        PlayerSpawner spawner = new PlayerSpawner(_playerConfig, _bulletConfig, input, _playerSpawnPoint);

        spawner.Spawn();

        foreach (var enemySpawner in _enemySpawners)
        {
            enemySpawner.Init();
        }

        _gameSettings.Init();
    }
}
