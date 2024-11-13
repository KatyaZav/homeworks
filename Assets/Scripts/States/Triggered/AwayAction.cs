using UnityEngine;

public class AwayAction : IAction
{
    private Enemy _enemy;
    private Mover _mover;
    private Transform _chasedObject;
    private Transform _curentTransform;

    public AwayAction(Enemy enemy, Transform chasedObject)
    {
        _enemy = enemy;
        _chasedObject = chasedObject;

        _curentTransform = _enemy.transform;

    }

    public void Activate()
    {
        _mover = _enemy.GetMover();
    }

    public void Deactivate()
    {
        _mover.ChangeVelocity(Vector3.zero);
    }

    public void Progressing()
    {
        Vector3 direction = _curentTransform.position - _chasedObject.transform.position;
        _mover.ChangeVelocity(direction);
    }
}
