using UnityEngine;

public class ChaseAction : IAction
{
    private Enemy _enemy;
    private Mover _mover;
    private Transform _chasedObject;
    private Transform _curentTransform;

    public ChaseAction(Enemy enemy, Transform chasedObject)
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
        Vector3 direction = _chasedObject.transform.position - _curentTransform.position;
        _mover.ChangeVelocity(direction);
    }
}
