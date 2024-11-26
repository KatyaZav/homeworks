using System;

public interface IConditions
{
    public event Action Completed;

    public void Enable();
    public void Disable();
}
