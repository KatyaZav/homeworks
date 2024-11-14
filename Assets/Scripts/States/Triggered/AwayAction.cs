using UnityEngine;

public class AwayAction : IState
{
    private Mover _mover;
    private Transform _chasedObject;
    private Transform _curentTransform;

    public AwayAction(Mover mover, Transform curentTransform, Transform chasedObject)
    {
        _mover = mover;
        _chasedObject = chasedObject;

        _curentTransform = curentTransform;

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
        Vector3 direction = _curentTransform.position - _chasedObject.transform.position;
        _mover.ChangeVelocity(direction);
    }
}
