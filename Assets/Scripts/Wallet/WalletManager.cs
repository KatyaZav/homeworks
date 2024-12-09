using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    private bool _isInit;
    private InputHandler _inputHandler;

    private CurrenceType _currentType = 0;

    public void Init(InputHandler input, Wallet wallet)
    {
        CurrentWallet = wallet;
        _inputHandler = input;

        _isInit = true;
    }

    public Wallet CurrentWallet { get; private set; }

    private void Update()
    {
        if (_isInit == false)
            return;

        if (_inputHandler.GetAddKeyDown)
        {
            CurrentWallet.Currencies[_currentType].Add(1);
        }

        if (_inputHandler.GetRemoveKeyDown)
        {
            CurrentWallet.Currencies[_currentType].Remove(1);
        }

        if (_inputHandler.GetNextKeyDown)
        {
            ChooseNext();
        }

        if (_inputHandler.GetPreviousKeyDown)
        {
            ChoosePrevious();
        }
    }

    private void ChooseNext()
    {
        int current = (int)_currentType;
        current++;

        _currentType = (CurrenceType) Mathf.Min(current, CurrentWallet.Currencies.Count - 1);
    }

    private void ChoosePrevious()
    {
        int current = (int)_currentType;
        current--;

        _currentType = (CurrenceType)Mathf.Max(current, 0);
    }
}
