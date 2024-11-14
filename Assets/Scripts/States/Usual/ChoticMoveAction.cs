using System;
using UnityEngine;

public class ChoticMoveAction : IState
{
    private float _timeBetweenChange;
    private float _curentTime;

    private Mover _mover;

    public ChoticMoveAction(float timeBetweenChange, Mover mover)
    {
        _timeBetweenChange = timeBetweenChange;
        _mover = mover;
    }

    private float GetRandom() => UnityEngine.Random.Range(-1f, 1f);
    private Vector3 GetRandomVector() => new Vector3(GetRandom(), 0, GetRandom()); 

    public void Enter()
    {
        _curentTime = 0;
        ChangeMovePoint();
    }

    public void Exit()
    {
        _mover.ChangeVelocity(Vector3.zero);
    }

    public void Update()
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
