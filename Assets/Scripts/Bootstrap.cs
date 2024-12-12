using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private const float Time = 10;

    [SerializeField] private WalletManager _walletManager;
    [SerializeField] private Transform _walletPosition;

    [SerializeField] private ValueView _valueUiPrefab;
    [SerializeField] private List<ValueConfig> _valueConfigs;

    [SerializeField] private TimerManager _timerManager;
    [SerializeField] private Transform _timerPlace;
    [SerializeField] private SliderTimerUI _prefabTimersUI;
    [SerializeField] private ObjectTimer _heartTimer;
        
    void Start()
    {
        InputHandler input = new InputHandler();

        InitWallet(input);
        InitTimer(input);
    }

    private void InitWallet(InputHandler input)
    {
        List<Currency> currents = new();

        foreach (CurrenceType type in Enum.GetValues(typeof(CurrenceType)))
        {
            ValueConfig config = _valueConfigs.Find(c => c.Type == type);

            if (config == null)
                throw new System.NullReferenceException($"Not found value of type {type}");

            Currency curency = new Currency(new Stat<int>(config.OriginalValue), config);
            currents.Add(curency);

        }

        var currentWallet = new Wallet(currents);

        _walletManager.Init(input, currentWallet);
        
        foreach (var currency in currentWallet.Currencies)
        {
            MakeCurrenceUI(currency.Value.Config);
        }
        
        //MakeCurrenceUI(config);
    }

    private void MakeCurrenceUI(ValueConfig config)
    {
        ValueView valueUi = Instantiate(_valueUiPrefab, _walletPosition);
        valueUi.Init(_walletManager.CurrentWallet.Currencies[config.Type], config);
    }

    private void InitTimer(InputHandler input)
    {
        Timer timer = new Timer(this);

        _timerManager.Init(input, timer, Time);

        BaseTimerUI timerUi = Instantiate(_prefabTimersUI, _timerPlace);
        timerUi.Init(timer, Time);

        ObjectTimer heartTimerUI = Instantiate(_heartTimer, _timerPlace);
        heartTimerUI.Init(timer, Time);
    }
}
