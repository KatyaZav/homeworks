using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    private bool _isInit;
    private InputHandler _inputHandler;

    private int _currentType = 0;

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
            Debug.Log(_currentType.ToString() + CurrentWallet.Currencies[_currentType].Value.Value);
        }

        if (_inputHandler.GetRemoveKeyDown)
        {
            CurrentWallet.Currencies[_currentType].Remove(1);
            Debug.Log(_currentType.ToString() + CurrentWallet.Currencies[_currentType].Value.Value);
        }

        if (_inputHandler.GetNextKeyDown)
        {
            ChooseNext();
            Debug.Log(_currentType.ToString() + CurrentWallet.Currencies[_currentType].Value.Value);
        }

        if (_inputHandler.GetPreviousKeyDown)
        {
            ChoosePrevious();
            Debug.Log(_currentType.ToString() + CurrentWallet.Currencies[_currentType].Value.Value);
        }
    }

    private void ChooseNext()
    {
        int current = _currentType;
        current++;

        _currentType = Mathf.Min(current, CurrentWallet.Currencies.Count - 1);
    }

    private void ChoosePrevious()
    {
        int current = _currentType;
        current--;

        _currentType = Mathf.Max(current, 0);
    }
}
