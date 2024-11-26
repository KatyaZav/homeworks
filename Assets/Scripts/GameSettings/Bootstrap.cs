using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform[] _enemySpawnPoins;
    [SerializeField] private GameSettings _gameSettings;

    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private PlayerConfig _playerConfig;

    [SerializeField] private float _waitTime;

    void Start()
    {
        InputHandler input = new InputHandler();
        PlayerSpawner spawner = new PlayerSpawner(_playerConfig, _bulletConfig, input, _playerSpawnPoint);

        spawner.Spawn();

        foreach (var enemySpawnPoint in _enemySpawnPoins)
        {
            EnemySpawner eSpawner = new EnemySpawner(_enemyConfig, enemySpawnPoint, _waitTime, this);
            eSpawner.StartSpawning();
        }

        _gameSettings.Init();
    }
}
