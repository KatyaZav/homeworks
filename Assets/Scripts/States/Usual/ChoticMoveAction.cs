using System;
using UnityEngine;

public class ChoticMoveAction : IAction
{
    private float _timeBetweenChange;
    private float _curentTime;

    private Enemy _enemy;
    private Mover _mover;

    public ChoticMoveAction(float timeBetweenChange, Enemy thisObject)
    {
        _timeBetweenChange = timeBetweenChange;

        _enemy = thisObject;
    }

    private float GetRandom() => UnityEngine.Random.Range(-1f, 1f);
    private Vector3 GetRandomVector() => new Vector3(GetRandom(), 0, GetRandom()); 

    public void Activate()
    {
        _mover = _enemy.GetMover();
        
        _curentTime = 0;
        ChangeMovePoint();
    }

    public void Deactivate()
    {
        _mover.ChangeVelocity(Vector3.zero);
    }

    public void Progressing()
    {
        _curentTime += Time.deltaTime;

        if ( _curentTime > _timeBetweenChange)
        {
            _curentTime = 0;
            ChangeMovePoint();
        }
    }

    private void ChangeMovePoint()
    {
        _mover.ChangeVelocity(GetRandomVector());
    }
}
