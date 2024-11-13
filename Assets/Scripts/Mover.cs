using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover
{
    private float _speed;
    private Rigidbody _rigidbody;

    public Mover(float speed, Rigidbody rigidbody)
    {
        _speed = speed;
        _rigidbody = rigidbody;
    }

    public void ChangeVelocity(Vector3 direction)
    {
        _rigidbody.velocity = direction.normalized * _speed;
    }
}
