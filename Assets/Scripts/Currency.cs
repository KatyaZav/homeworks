using UnityEngine;

public class Currency
{
    public Currency(Stat<int> value)
    {
        Value = value;
    }

    public Stat<int> Value { get; private set; }

    public void Add(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Try add negative value");
        }

        Value.Value += amount;
    }

    public void Remove(int amount)
    {
        float tmp = Value.Value - amount;

        if (tmp < 0)
            throw new System.ArgumentOutOfRangeException("Try remove more than have");

        Value.Value -= amount;
    }
}
