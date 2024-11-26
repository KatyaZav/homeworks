using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private const float WinTime = 10;
    private const int WinEnemyCount = 10;
    private const int LoseEnemyCount = 10;

    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform[] _enemySpawnPoins;
    [SerializeField] private GameSettings _gameSettings;

    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private PlayerConfig _playerConfig;

    [SerializeField] private float _waitTime;

    [SerializeField] private WinningSettings _winningSettings;
    [SerializeField] private LosingSettings _losingSettings;

    private GameSettings _settings;

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

        IConditions win = ChooseWinSettings(spawner);
        IConditions loose = ChooseLoseSettings(spawner);

        _settings = new GameSettings(win, loose);
    }

    private void OnDisable()
    {
        _settings.OnDisable();
    }

    private IConditions ChooseWinSettings(PlayerSpawner playerSpawner)
    {
        switch (_winningSettings)
        {
            case WinningSettings.killing:
                return new ControllKillingState(WinEnemyCount);
            case WinningSettings.waiting:
                return new ControlTimeState(this, WinTime, playerSpawner.Player);
        }
    
        return new ControlTimeState(this, WinTime, playerSpawner.Player);
    }

    private IConditions ChooseLoseSettings(PlayerSpawner playerSpawner)
    {
        switch (_losingSettings)
        {
            case LosingSettings.overspawned:
                return new ControlEnemyState(LoseEnemyCount);
            case LosingSettings.killed:
                return new ControlPlayerState(playerSpawner.Player);
        }
        
        return new ControlPlayerState(playerSpawner.Player);
    }
}
