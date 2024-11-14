using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : IState
{
    private const float StopDirection = 1.6f;

    private Mover _mover;    
    private Transform _objectTransform;

    private Queue<Vector3> _patrolPoints = new Queue<Vector3>();
    private Vector3 _curentPoint;

    public PatrolAction(Transform transform, Mover mover, Vector3[] points)
    {
        _objectTransform = transform;
        _mover = mover;


        foreach(var point in points)
        {
            _patrolPoints.Enqueue(point);
        }
    }

    public void Enter()
    {
        _curentPoint = _patrolPoints.Peek();
    }

    public void Exit()
    {
        _mover.ChangeVelocity(Vector3.zero);
    }

    public void Update()
    {
        var direction = _curentPoint - _objectTransform.transform.position;
        _mover.ChangeVelocity(direction);

        if (direction.magnitude < StopDirection)
        {
            _curentPoint = _patrolPoints.Dequeue();
            _patrolPoints.Enqueue(_curentPoint);
            _curentPoint = _patrolPoints.Peek();
        }
    }
}
