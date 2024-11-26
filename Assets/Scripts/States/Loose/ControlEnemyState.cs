using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlEnemyState : IConditions
{
    private int _needCount;

    public ControlEnemyState(int count)
    {
        _needCount = count;
    }

    public event Action Completed;

    public void Enable()
    {
        EnemySpawner.ListEnemy.Added += OnAdd;
    }

    public void Disable()
    {
        EnemySpawner.ListEnemy.Added -= OnAdd;
    }

    private void OnAdd(List<Enemy> list)
    {
        if (list.Count >= _needCount)
            Completed?.Invoke();
    }
}
