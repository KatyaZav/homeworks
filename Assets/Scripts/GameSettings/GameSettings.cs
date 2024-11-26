using UnityEngine;

public class GameSettings
{
    private PlayerSpawner _playerSpawner;

    private IConditions _winSetting, _looseSetting;

    public GameSettings(IConditions winningSettings, IConditions losingSettings)
    {
        _winSetting = winningSettings;
        _looseSetting = losingSettings;

        _winSetting.Enable();
        _looseSetting.Enable();

        _winSetting.Completed += OnWin;
        _looseSetting.Completed += OnLose;
    }

    public void OnDisable()
    {
        _winSetting.Disable();
        _looseSetting.Disable();

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
