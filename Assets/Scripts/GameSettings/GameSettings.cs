using System;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private WinningSettings _winningSettings;
    [SerializeField] private LosingSettings _losingSettings;

    [SerializeField] private PlayerSpawner _playerSpawner;

    private IState _winSetting, _looseSetting;

    public void Init()
    {
        ChooseWinSettings();
        ChooseLoseSettings();

        _winSetting.Completed += OnWin;
        _looseSetting.Completed += OnLose;
    }

    private void OnDisable()
    {
        _winSetting.Exit();
        _looseSetting.Exit();

        _winSetting.Completed -= OnWin;
        _looseSetting.Completed -= OnLose;
    }

    private void OnLose()
    {
        Debug.Log("Lose");
    }

    private void OnWin()
    {
        Debug.Log("Win");
    }

    private void ChooseLoseSettings()
    {
        switch (_losingSettings)
        {
            case LosingSettings.overspawned:
                _looseSetting = new ControlEnemyState();
                break;
            case LosingSettings.killed:
                _looseSetting = new ControlPlayerState(_playerSpawner.Player);
                break;
        }

        _looseSetting.Enter();
    }

    private void ChooseWinSettings()
    {
        switch (_winningSettings)
        {
            case WinningSettings.killing:
                _winSetting = new ControllKillingState();
                break;
            case WinningSettings.waiting:
                _winSetting = new ControlTimeState();
                break;
        }

        _winSetting.Enter();
    }
}

public enum WinningSettings
{
    waiting,
    killing
}

public enum LosingSettings
{
    killed,
    overspawned
}
