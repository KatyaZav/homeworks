using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private WalletManager _walletManager;
    [SerializeField] private InputHandler _inputHandler;
    
    void Start()
    {
        var currentWallet = new Wallet(
            new Currency(new Stat<int>(0)), new Currency(new Stat<int>(0)), new Currency(new Stat<int>(0)));

        _walletManager.Init(_inputHandler, currentWallet);
    }
}
