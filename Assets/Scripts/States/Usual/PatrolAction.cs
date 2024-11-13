using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : IAction
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

    public void Activate()
    {
        _curentPoint = _patrolPoints.Peek();
        _mover = _enemy.GetMover();
    }

    public void Deactivate()
    {
        _mover.ChangeVelocity(Vector3.zero);
    }

    public void Progressing()
    {
        var direction = _curentPoint - _enemy.transform.position;
        _mover.ChangeVelocity(direction);

        if (direction.magnitude < StopDirection)
        {
            Debug.Log("New path");
            _curentPoint = _patrolPoints.Dequeue();
            _patrolPoints.Enqueue(_curentPoint);
            _curentPoint = _patrolPoints.Peek();
        }
    }
}
