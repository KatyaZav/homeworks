using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllKillingState : IState
{
    private int _count, _needCount;

    public ControllKillingState(int needCount)
    {
        _needCount = needCount;
    }

    public event Action Completed;

    public void Enter()
    {
        _count = 0;
        EnemySpawner.ListEnemy.Removed += OnRemove;
    }

    public void Exit()
    {
        EnemySpawner.ListEnemy.Removed -= OnRemove;
    }

    private void OnRemove(List<Enemy> list)
    {
        _count++;

        if (_count == _needCount)
        {
            Completed?.Invoke();
        }
    }
}
