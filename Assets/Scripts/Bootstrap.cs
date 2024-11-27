using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private WalletManager _walletManager;
        
    void Start()
    {
        var currentWallet = new Wallet(
            new Currency(new Stat<int>(0)), new Currency(new Stat<int>(0)), new Currency(new Stat<int>(0)));

        InputHandler input = new InputHandler();

        _walletManager.Init(input, currentWallet);
    }
}
