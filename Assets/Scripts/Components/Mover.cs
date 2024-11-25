using UnityEngine;

public class Mover
{
    private Rigidbody _rigidbody;
    
    private float _speed;

    public Mover(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void MoveToDirection(Vector3 direction)
    {
        direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = direction.normalized * _speed;
    }
}
