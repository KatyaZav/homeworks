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

    public void Init()
    {
        PlayerController player = Instantiate(_playerPrefab, transform.position, transform.rotation);
        
        Mover mover = new Mover(player.Rigidbody, _speed);
        Rotator rotator = new Rotator(player.gameObject.transform, _rotationSpeed);
        Shooter shooter = new Shooter(_bullet, _bulletSpeed, player.ShootPosition, _enemyMask, _damage);
        Health health = new Health(_health);

        player.Init(_inputHandler, mover, rotator, shooter, health);
    }
}
