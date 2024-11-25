using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private float _speed;

    private InputHandler _inputHandler;
    private Mover _mover;
    private Rotator _rotator;
    private Shooter _shooter;

    private bool _wasInit;

    public void Init(InputHandler input, Mover mover, Rotator rotator, Shooter shooter)
    {
        _inputHandler = input;
        _mover = mover;
        _rotator = rotator;
        _shooter = shooter;

        _rigidbody = GetComponent<Rigidbody>();
        _wasInit = true;
    }

    
    [field: SerializeField] public Transform ShootPosition { get; private set; }
    public Rigidbody Rigidbody => _rigidbody? _rigidbody : GetComponent<Rigidbody>();

    private void Update()
    {
        if (_wasInit == false)
            return;

        float horizontalMove = _inputHandler.GetHorizontalInput();
        float vercicalMove = _inputHandler.GetVerticalInput();

        Vector3 direction = new Vector3(horizontalMove, 0, vercicalMove);
        _mover.MoveToDirection(direction);
        _rotator.RotateTo(direction);

        if (_inputHandler.GetShootKeyDown())
            _shooter.Shoot();
    }
}
