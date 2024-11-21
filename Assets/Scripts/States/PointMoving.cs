using UnityEngine;

public class PointMoving : IState
{
    private NavigationMover _navigationMover;

    public PointMoving(NavigationMover mover)
    {
        _navigationMover = mover;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void SetPoint(Vector3 point)
    {
        StartMoveTo(point);
    }

    public void Update()
    {
        _navigationMover.SetIsMoving(_navigationMover.HasPath);
    }

    private void StartMoveTo(Vector3 vector)
    {
        _navigationMover.SetIsMoving(true);
        _navigationMover.SetPoint(vector);
    }
}
