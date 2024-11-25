using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private float _speed, _rotationSpeed;

    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _bulletSpeed;

    private void Start()
    {
        PlayerController player = Instantiate(_playerPrefab, transform.position, transform.rotation);
        
        Mover mover = new Mover(player.Rigidbody, _speed);
        Rotator rotator = new Rotator(player.gameObject.transform, _rotationSpeed);
        Shooter shooter = new Shooter(_bullet, _bulletSpeed, player.ShootPosition);

        player.Init(_inputHandler, mover, rotator, shooter);
    }
}
