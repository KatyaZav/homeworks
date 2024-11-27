using System.Collections.Generic;

public class Wallet
{
    public Wallet(Currency money, Currency diamonds, Currency energy)
    {
        Money = money;
        Diamonds = diamonds;
        Energy = energy;

        Currencies = new List<Currency>();
        Currencies.Add(Money);
        Currencies.Add(Energy);
        Currencies.Add(Diamonds);
    }

    public Currency Money { get; private set; }
    public Currency Diamonds { get; private set; }
    public Currency Energy { get; private set; }

    public List<Currency> Currencies { get; private set; }

}

public enum CurrenceType
{
    money = 0,
    diamonds = 1,
    energy = 2
}