using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private WalletManager _walletManager;
    [SerializeField] private Transform _walletPosition;

    [SerializeField] private ValueUi _valueUiPrefab;
    [SerializeField] private ValueConfig[] _valueConfigs;

    [SerializeField] private TimerManager _timerManager;
        
    void Start()
    {
        InputHandler input = new InputHandler();

        InitWallet(input);
        InitTimer(input);
    }

    private void InitWallet(InputHandler input)
    {
        var currentWallet = new Wallet(
            new Currency(new Stat<int>(0)), new Currency(new Stat<int>(0)), new Currency(new Stat<int>(0)));

        _walletManager.Init(input, currentWallet);

        int index = 0;
        foreach (var config in _valueConfigs)
        {
            ValueUi valueUi = Instantiate(_valueUiPrefab, _walletPosition);
            valueUi.Init(_walletManager.CurrentWallet.Currencies[index], _valueConfigs[index]);
            index++;
        }
    }
    private void InitTimer(InputHandler input)
    {
        Timer timer = new Timer(this);

        _timerManager.Init(input, timer);
    }
}
