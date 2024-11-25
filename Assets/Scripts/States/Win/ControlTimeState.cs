using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTimeState : IState
{
    public ControlTimeState()
    {
    }

    public event Action Completed;

    public void Enter()
    {
        //throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
