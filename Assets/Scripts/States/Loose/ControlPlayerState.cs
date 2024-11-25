using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerState : IState
{
    private PlayerController _player;

    public ControlPlayerState(PlayerController player)
    {
        _player = player;
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
