using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private InputHandler _input;
    private Timer _timer;

    private float _maxTime;
    private bool _isInit;
    public void Init(InputHandler input, Timer timer, float maxTime)
    {
        _input = input;
        _timer = timer;
        _maxTime = maxTime;

        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            return;

        if (_input.GetStartTimerKeyDown)
        {
            _timer.StartTimer(_maxTime);
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

