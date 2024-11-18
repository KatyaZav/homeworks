using UnityEngine;
using UnityEngine.AI;

public class NavigationMover
{
    private NavMeshAgent _navMeshAgent;

    public NavigationMover(NavMeshAgent navMeshAgent)
    {
        _navMeshAgent = navMeshAgent;
    }

    public bool isGoing => _navMeshAgent.isStopped == false;
    public bool HasPath => _navMeshAgent.hasPath;

    public void SetPoint(Vector3 point)
    {
        _navMeshAgent.SetDestination(point);
    }

    public void SetIsMoving(bool isMoving)
    {
        _navMeshAgent.isStopped = isMoving == false;
    }
}
