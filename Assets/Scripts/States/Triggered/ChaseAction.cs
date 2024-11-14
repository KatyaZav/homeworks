using UnityEngine;

public class ChaseAction : IState
{
    private Mover _mover;
    private Transform _chasedObject;
    private Transform _curentTransform;

    public ChaseAction(Mover mover, Transform currentObject, Transform chasedObject)
    {
        _mover = mover;
        _chasedObject = chasedObject;
        _curentTransform = currentObject;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
        _mover.ChangeVelocity(Vector3.zero);
    }

    public void Update()
    {
        Vector3 direction = _chasedObject.transform.position - _curentTransform.position;
        _mover.ChangeVelocity(direction);
    }
}
