using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllKillingState : IState
{
    public ControllKillingState()
    {
    }

    public event Action Completed;

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
