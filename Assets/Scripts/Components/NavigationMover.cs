using UnityEngine;
using UnityEngine.AI;

public class NavigationMover
{
    private NavMeshAgent _navMeshAgent;

    public NavigationMover(NavMeshAgent navMeshAgent)
    {
        _navMeshAgent = navMeshAgent;
    }

    public void SetPoint(Vector3 point)
    {
        _navMeshAgent.SetDestination(point);
    }

    public void StopMoving(bool isStop = true)
    {
        _navMeshAgent.isStopped = isStop;
    }
}
