using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string VerticalAxis = "Vertical"; 
    private const string HorizontalAxis = "Horizontal"; 

    [SerializeField] private Rigidbody _rigidbody;

    private Mover _mover;
    private Rotator _rotator;
    
    void Start()
    {
        _mover = new Mover(10, _rigidbody);
        _rotator = new Rotator(10, transform);
    }

    void Update()
    {
        float verticalInput = Input.GetAxisRaw(VerticalAxis);
        float horizontalInput = Input.GetAxisRaw(HorizontalAxis);

        var direction = new Vector3(horizontalInput, 0, verticalInput);
        _mover.ChangeVelocity(direction);
        _rotator.RotateTo(direction);
    }
}
