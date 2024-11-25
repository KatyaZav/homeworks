using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerState : IState
{
    public event Action Completed;
    
    private PlayerController _player;

    public ControlPlayerState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        _player.Health.Changed += OnHealthChanged;
    }

    public void Exit()
    {
        _player.Health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged(float hp)
    {
        if (hp == 0)
        {
            Completed?.Invoke();
        }
    }
}
