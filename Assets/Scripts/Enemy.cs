using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _agroRaduis;

    private IAction _triggerdAction;
    private IAction _stayingAction;

    private IAction _currentAction;
    
    void Update()
    {
        _currentAction?.Progressing();

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

    public void Init(IAction triggerdAction, IAction stayingAction)
    {
        _triggerdAction = triggerdAction;
        _stayingAction = stayingAction;

        _currentAction = _stayingAction;
    }

    private void ChangeAction(IAction action)
    {
        _currentAction?.Deactivate();
        _currentAction = action;
        _currentAction.Activate();
    }
}
