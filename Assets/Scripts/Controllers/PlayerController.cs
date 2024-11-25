using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  
public class PlayerController : MonoBehaviour, IDamageble
{
    private Rigidbody _rigidbody;
    
    private float _speed;

    private InputHandler _inputHandler;
    private Mover _mover;
    private Rotator _rotator;
    private Shooter _shooter;
    private Health _health;

    private bool _wasInit;
    private float _horizontalMove, _vercicalMove;

    public void Init(InputHandler input, Mover mover, Rotator rotator, Shooter shooter, Health health)
    {
        _inputHandler = input;
        _mover = mover;
        _rotator = rotator;
        _shooter = shooter;
        _health = health;

        _rigidbody = GetComponent<Rigidbody>();
        _wasInit = true;
    }

    [field: SerializeField] public Transform ShootPosition { get; private set; }
    public Rigidbody Rigidbody => _rigidbody? _rigidbody : GetComponent<Rigidbody>();

    public Stat<float> Health => _health.CurrentHealth;

    private void Update()
    {
        if (_wasInit == false)
            return;

        if (_inputHandler.GetShootKeyDown())
            _shooter.Shoot();
        
        _horizontalMove = _inputHandler.GetHorizontalInput();
        _vercicalMove = _inputHandler.GetVerticalInput();
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(_horizontalMove, 0, _vercicalMove);
        _mover.MoveToDirection(direction);
        _rotator.RotateTo(direction);        
    }

    public void Add(float health)
    {
        _health.Add(health);
    }

    public void Remove(float damage)
    {
        _health.Remove(damage);    
    }
}
