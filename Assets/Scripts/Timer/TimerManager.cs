using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private const float Time = 10;

    private InputHandler _input;
    private Timer _timer;

    private bool _isInit;
    public void Init(InputHandler input, Timer timer)
    {
        _input = input;
        _timer = timer;
        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            return;

        if (_input.GetStartTimerKeyDown)
        {
            _timer.StartTimer(Time);
        }

        if (_input.GetStopTimerKeyDown)
        {
            _timer.StopTimer();
        }

        if (_input.GetPauseTimerKeyDown)
        {
            if (_timer.IsPause)
                _timer.ContinueTimer();
            else
                _timer.PauseTimer();
        }
    }
}

