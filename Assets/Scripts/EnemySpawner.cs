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
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _player;

    private Vector3[] _patrolPoints;

    void Start()
    {
        Init();
        SpawnEnemy();        
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);

        IState triggerdAction = GetTriggerdState(_triggerdAction, enemy);
        IState stayingAction = GetStayingState(_stayingAction, enemy);

        enemy.Init(triggerdAction, stayingAction);
    }

    private void Init()
    {
        _patrolPoints = new Vector3[_points.Length];
        for (var i = 0; i < _points.Length; i++)
        {
            _patrolPoints[i] = _points[i].position;
        }
    }

    private IState GetStayingState(StayingAction stayingAction, Enemy enemy)
    {
        switch (stayingAction)
        {
            case StayingAction.stay:
                return new StayAction();
            case StayingAction.patrol:
                return new PatrolAction(enemy, _patrolPoints);
            case StayingAction.chaotic:
                return new ChoticMoveAction(1, enemy);
        }

        Debug.LogError("Didn't found state");
        return new StayAction();
    }

    private IState GetTriggerdState(TriggerdAction action, Enemy enemy)
    {
        switch (action)
        {
            case TriggerdAction.angry:
                return new ChaseAction(enemy, _player);
            case TriggerdAction.destroyable:
                return new DestroyAction(enemy.gameObject, _particles);
            case TriggerdAction.shy:
                return new AwayAction(enemy, _player);
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


