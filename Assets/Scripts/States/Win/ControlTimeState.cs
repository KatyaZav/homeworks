using System;
using System.Collections;
using UnityEngine;

public class ControlTimeState : IConditions
{
    private MonoBehaviour _baseMonobehaviour;
    private PlayerController _player;
    private float _time;

    private Coroutine _coroutine;

    public ControlTimeState(MonoBehaviour baseObj, float time, PlayerController player)
    {
        _baseMonobehaviour = baseObj;
        _time = time;
        _player = player;
    }

    public event Action Completed;

    public void Enable()
    {
        _coroutine = _baseMonobehaviour.StartCoroutine(Timer());
        
        _player.Health.Changed += OnHealthChange;
    }

    public void Disable()
    {
        _baseMonobehaviour.StopCoroutine(_coroutine);

        _player.Health.Changed -= OnHealthChange;
    }
   
    private void OnHealthChange(float health)
    {
        if (health <= 0)
        {
            Debug.Log("player dead");
            _baseMonobehaviour.StopCoroutine(_coroutine);
        }
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
