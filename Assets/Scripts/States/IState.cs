
using UnityEngine;

public interface IState 
{
    public void Enter();
    public void Exit();
    public void SetPoint(Vector3 point);
    public void Update();
}
