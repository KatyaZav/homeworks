using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllKillingState : IConditions
{
    private int _count, _needCount;
    private bool _isComplete;

    public ControllKillingState(int needCount)
    {
        _needCount = needCount;
    }

    public event Action Completed;

    public void Enable()
    {
        _count = 0;
        _isComplete = false;

        EnemySpawner.ListEnemy.Removed += OnRemove;
    }

    public void Disable()
    {
        EnemySpawner.ListEnemy.Removed -= OnRemove;
    }

    private void OnRemove(List<Enemy> list)
    {
        if (_isComplete)
            return;

        _count++;

        if (_count == _needCount)
        {
            Completed?.Invoke();
            _isComplete = true;
        }
    }
}
