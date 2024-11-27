using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action Completed;
    public event Action<float> TimeChanged;

    private MonoBehaviour _root;
    private float _currentSeconds;

    private Coroutine _coroutine;
    private bool _isStarted;

    public Timer(MonoBehaviour root)
    {
        _root = root;
    }

    public bool IsPause { get; private set; }

    public void StartTimer(float seconds)
    {
        Debug.Log("Start timer");
        _coroutine = _root.StartCoroutine(TimerLogic(seconds));
        _isStarted = true;
    }

    public void PauseTimer()
    {
        if (_coroutine == null)
            throw new ArgumentNullException("Timer is null, but tried to stop");
        
        if (_isStarted == false)
            throw new ArgumentNullException("Timer is null, but tried to stop");

        Debug.Log("Pause timer");
        IsPause = true;
        _root.StopCoroutine(_coroutine);
    }

    public void ContinueTimer()
    {
        if (_isStarted == false)
            throw new ArgumentNullException("Timer is null, but tried to stop");

        Debug.Log("Continue timer");
        IsPause = false;
        _coroutine = _root.StartCoroutine(TimerLogic(_currentSeconds));
    }

    public void StopTimer()
    {
        if (_coroutine == null)
            throw new ArgumentNullException("Timer is null, but tried to stop");

        Debug.Log("Stop timer");
        _root.StopCoroutine(_coroutine);
        _coroutine = null;
        _currentSeconds = 0;
        _isStarted = false;
    }

    private IEnumerator TimerLogic(float time)
    {
        _currentSeconds = time;

        while (_currentSeconds > 0)
        {
            _currentSeconds -= Time.deltaTime;
            TimeChanged?.Invoke(_currentSeconds);

            yield return null;
        }

        Debug.Log("Complete timer");
        Completed?.Invoke();
        StopTimer();
    }
}
