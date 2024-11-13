using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private StayingAction _stayingAction;
    [SerializeField] private TriggerdAction _triggerdAction;

    [Header("Settings")]
    [SerializeField] private ParticleSystem _particles;

    void Start()
    {
        var enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
        enemy.Init();

        IAction triggerdAction = GetTriggerdState(_triggerdAction, enemy);
        IAction stayingAction = GetStayingState(_stayingAction, enemy);

        enemy.Init(triggerdAction, stayingAction);
    }

    private IAction GetStayingState(StayingAction stayingAction, Enemy enemy)
    {
        switch (stayingAction)
        {
            case StayingAction.stay:
                return new StayAction();
            case StayingAction.patrol:
                break;
            case StayingAction.chaotic:
                return new ChoticMoveAction(1, enemy);
        }

        Debug.LogError("Didn't found state");
        return new StayAction();
    }

    private IAction GetTriggerdState(TriggerdAction action, Enemy enemy)
    {
        switch (action)
        {
            case TriggerdAction.angry:
                break;
            case TriggerdAction.destroyable:
                return new DestroyAction(enemy.gameObject, _particles);
            case TriggerdAction.shy:
                break;
        }

        Debug.LogError("Didn't found state");
        return new DestroyAction(enemy.gameObject, _particles);
    }

    public enum StayingAction
    {
        stay = 0,
        patrol = 1,
        chaotic = 2,
    }

    public enum TriggerdAction
    {
        shy = 0,
        angry = 1,
        destroyable = 2,
    }
}


