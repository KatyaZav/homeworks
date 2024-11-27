using System;
using UnityEngine;

public class BaseTimerUI : MonoBehaviour
{
    protected float _maxValue;
    
    private Timer _timer;

    public void Init(Timer timer, float maxValue)
    {
        _timer = timer;
        _maxValue = maxValue;
        OnInit();

        OnValueChange(maxValue);

        _timer.TimeChanged += OnValueChange;
    }


    private void OnDisable()
    {
        _timer.TimeChanged -= OnValueChange;        
    }
    
    protected virtual void OnInit()
    {
    }

    protected virtual void OnValueChange(float value)
    {
    }
}
