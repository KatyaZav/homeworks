using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private float _speed;

    private void Start()
    {
        PlayerController player = Instantiate(_playerPrefab, transform.position, transform.rotation);
        Mover mover = new Mover(player.Rigidbody, _speed);
        player.Init(_inputHandler, mover);
    }
}
