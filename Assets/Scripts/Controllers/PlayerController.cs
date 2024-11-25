using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  
public class PlayerController : MonoBehaviour
{
    private float _speed;

    private InputHandler _inputHandler;
    private Mover _mover;
    private Rotator _rotator;

    private Rigidbody _rigidbody;
    private bool _wasInit;

    public void Init(InputHandler input, Mover mover, Rotator rotator)
    {
        _inputHandler = input;
        _mover = mover;
        _rotator = rotator;

        _rigidbody = GetComponent<Rigidbody>();
        _wasInit = true;
    }

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
    }
}
