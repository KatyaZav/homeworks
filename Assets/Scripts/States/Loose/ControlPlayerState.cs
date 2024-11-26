using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerState : IConditions
{
    public event Action Completed;
    
    private PlayerController _player;

    public ControlPlayerState(PlayerController player)
    {
        _player = player;
    }

    public void Enable()
    {
        _player.Health.Changed += OnHealthChanged;
    }

    public void Disable()
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
