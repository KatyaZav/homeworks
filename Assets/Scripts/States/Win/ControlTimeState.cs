using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTimeState : IState
{
    private MonoBehaviour _baseMonobehaviour;
    private float _time;

    private Coroutine _coroutine;

    public ControlTimeState(MonoBehaviour baseObj, float time)
    {
        _baseMonobehaviour = baseObj;
        _time = time;
    }

    public event Action Completed;

    public void Enter()
    {
        _coroutine = _baseMonobehaviour.StartCoroutine(Timer());
    }

    public void Exit()
    {
        _baseMonobehaviour.StopCoroutine(_coroutine);
    }

    private IEnumerator Timer()
    {
        float currentTime = _time;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }

        Completed?.Invoke();
    }
}
