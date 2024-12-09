using System.Collections.Generic;

public class Wallet
{
    public Wallet(Currency money, Currency diamonds, Currency energy)
    {
        Currencies = new Dictionary<CurrenceType, Currency>();

        Currencies[CurrenceType.money] = money;
        Currencies[CurrenceType.diamonds] = diamonds;
        Currencies[CurrenceType.energy] = energy;
    }

    public Dictionary<CurrenceType, Currency> Currencies { get; private set; }

}

public enum CurrenceType
{
    money = 0,
    diamonds = 1,
    energy = 2
}