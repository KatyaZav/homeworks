using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlEnemyState : IState
{
    private int _needCount;

    public ControlEnemyState(int count)
    {
        _needCount = count;
    }

    public event Action Completed;

    public void Enter()
    {
        EnemySpawner.ListEnemy.Added += OnAdd;
    }

    public void Exit()
    {
        EnemySpawner.ListEnemy.Added -= OnAdd;
    }

    private void OnAdd(List<Enemy> list)
    {
        if (list.Count >= _needCount)
            Completed?.Invoke();
    }
}
