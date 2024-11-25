using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private float _speed, _rotationSpeed;
    [SerializeField] private float _health;

    [SerializeField] private Bullet _bullet;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;

    private PlayerController _player;

    public void Init()
    {
        _player = Instantiate(_playerPrefab, transform.position, transform.rotation);
        
        Mover mover = new Mover(_player.Rigidbody, _speed);
        Rotator rotator = new Rotator(_player.gameObject.transform, _rotationSpeed);
        Shooter shooter = new Shooter(_bullet, _bulletSpeed, _player.ShootPosition, _enemyMask, _damage);
        Health health = new Health(_health);

        _player.Init(_inputHandler, mover, rotator, shooter, health);
    }

    public PlayerController Player => _player;
}
