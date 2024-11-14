using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _agroRaduis;
    [SerializeField] private Rigidbody _rigidbody;

    private Mover _mover;
    
    private IState _triggerdAction;
    private IState _stayingAction;

    private IState _currentAction;

    public Mover GetMover() => _mover;

    private void Update()
    {
        _currentAction?.Update();

        CheakAgroZone();
    }

    private void CheakAgroZone()
    {
        var player = Physics.OverlapSphere(transform.position, _agroRaduis, _mask.value);

        if (player.Length > 0 && _currentAction != _triggerdAction)
        {
            ChangeAction(_triggerdAction);
        }

        if (player.Length <= 0 && _currentAction != _stayingAction)
        {
            ChangeAction(_stayingAction); 
        }
    }

    public void Init()
    {
        _mover = new Mover(5, _rigidbody);
    }

    public void SetStates(IState triggerdAction, IState stayingAction)
    {
        _triggerdAction = triggerdAction;
        _stayingAction = stayingAction;

        ChangeAction(_stayingAction);
    }

    private void ChangeAction(IState action)
    {
        _currentAction?.Exit();
        _currentAction = action;
        _currentAction.Enter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _agroRaduis);
    }
}
