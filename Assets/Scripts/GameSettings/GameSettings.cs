using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private WinningSettings _winningSettings;
    [SerializeField] private LosingSettings _lingSettings;

    public void Init()
    {

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
