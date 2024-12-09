using System.Collections.Generic;
using System.Linq;

public class Wallet
{
    public Wallet(List<Currency> args)
    {
        Currencies = new Dictionary<CurrenceType, Currency>();

        foreach (Currency currency in args)
        {
            if (Currencies.Any(c => c.Value.Config.Type == currency.Config.Type))
                throw new System.ArgumentException("Wallet already contains value");

            Currencies[currency.Config.Type] = currency;
        }
    }

    public Dictionary<CurrenceType, Currency> Currencies { get; private set; }

}

public enum CurrenceType
{
    money = 0,
    diamonds = 1,
    energy = 2
}