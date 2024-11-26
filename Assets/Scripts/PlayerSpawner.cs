using UnityEngine;

public class PlayerSpawner
{
    private InputHandler _inputHandler;
    private PlayerController _playerPrefab;
    private float _speed, _rotationSpeed;
    private float _health;

    private Bullet _bullet;
    private LayerMask _enemyMask;
    private float _bulletSpeed;
    private float _damage;

    private Transform _spawnPoint;

    private PlayerController _player;

    public PlayerSpawner(PlayerConfig playerConfig, BulletConfig bulletConfig,
        InputHandler inputHandler, Transform transformPoint)
    {
        _inputHandler = inputHandler;

        _playerPrefab = playerConfig.Prefab;
        _speed = playerConfig.Speed;
        _rotationSpeed = playerConfig.RotationSpeed;
        _health = playerConfig.Health;

        _bullet = bulletConfig.BulletPrefab;
        _enemyMask = bulletConfig.EnemyMask;
        _bulletSpeed = bulletConfig.BulletSpeed;
        _damage = bulletConfig.Damage;

        _spawnPoint = transformPoint;
    }

    public void Spawn()
    {
        _player = GameObject.Instantiate(_playerPrefab, _spawnPoint.position, _spawnPoint.rotation);
        
        Mover mover = new Mover(_player.Rigidbody, _speed);
        Rotator rotator = new Rotator(_player.gameObject.transform, _rotationSpeed);
        Shooter shooter = new Shooter(_bullet, _bulletSpeed, _player.ShootPosition, _enemyMask, _damage);
        Health health = new Health(_health);

        _player.Init(_inputHandler, mover, rotator, shooter, health);
    }

    public PlayerController Player => _player;
}
