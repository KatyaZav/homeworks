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
        _winSetting.Completed -= OnWin;
        _looseSetting.Completed -= OnLose;
    }

    private void OnLose()
    {
        throw new NotImplementedException();
    }

    private void OnWin()
    {
        throw new NotImplementedException();
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
