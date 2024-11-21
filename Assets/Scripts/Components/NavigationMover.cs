using System;
using UnityEngine;
using UnityEngine.AI;

public class NavigationMover
{
    public event Action<Vector3> PointChanged;
    public event Action<bool> MovingChanged;

    private NavMeshAgent _navMeshAgent;

    public NavigationMover(NavMeshAgent navMeshAgent)
    {
        _navMeshAgent = navMeshAgent;
    }

    public bool isGoing => _navMeshAgent.isStopped == false;
    public bool HasPath => _navMeshAgent.hasPath;

    public void SetPoint(Vector3 point)
    {
        PointChanged?.Invoke(point);
        _navMeshAgent.SetDestination(point);
    }

    public void SetIsMoving(bool isMoving)
    {
        MovingChanged?.Invoke(isMoving);
        _navMeshAgent.isStopped = isMoving == false;
    }
}
