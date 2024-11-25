using System;

public interface IState
{
    public event Action Completed;

    public void Enter();
    public void Exit();
}
