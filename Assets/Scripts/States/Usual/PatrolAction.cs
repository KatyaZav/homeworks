using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : IState
{
    private const float StopDirection = 1.6f;

    private Mover _mover;
    private Enemy _enemy;
    private Queue<Vector3> _patrolPoints = new Queue<Vector3>();

    private Vector3 _curentPoint;

    public PatrolAction(Enemy enemy, Vector3[] points)
    {
        _enemy = enemy;

        foreach(var point in points)
        {
            _patrolPoints.Enqueue(point);
        }
    }

    public void Enter()
    {
        _curentPoint = _patrolPoints.Peek();
        _mover = _enemy.GetMover();
    }

    public void Exit()
    {
        _mover.ChangeVelocity(Vector3.zero);
    }

    public void Update()
    {
        var direction = _curentPoint - _enemy.transform.position;
        _mover.ChangeVelocity(direction);

        if (direction.magnitude < StopDirection)
        {
            _curentPoint = _patrolPoints.Dequeue();
            _patrolPoints.Enqueue(_curentPoint);
            _curentPoint = _patrolPoints.Peek();
        }
    }
}
