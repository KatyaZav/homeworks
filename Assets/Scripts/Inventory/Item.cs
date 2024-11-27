using System;

public class Item
{
    public int Id { get; }
    public int Count { get; private set; }

    public Item(int id, int count)
    {
        Id = id;
        Count = count;
    }

    public void Add(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException("Count under zero");

        Count += count;
    }

    public void Collect(int count)
    {
        if (Count < count)
            throw new ArgumentOutOfRangeException("Not enough items count to remove");

        if (count < 0)
            throw new ArgumentOutOfRangeException("Try to collect zero items count");

        Count -= count;
    }
}
