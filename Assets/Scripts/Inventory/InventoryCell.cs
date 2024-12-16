using System;

public class InventoryCell
{
    public InventoryCell()
    {
    }

    public InventoryCell(Item items, int count)
    {
        Items = items;
        Count = count;
    }

    public Item Items { get; private set; }
    public int Count { get; private set; }

    public bool CheakCorrectItem(Item item) => item == Items;

    public void TryAdd(Item item, int count)
    {
        if (CheakCorrectItem(item))
        {
            AddItemsCount(count);
        }
        else
        {
            throw new ArgumentException("Try add wrong item");
        }
    }

    public void TryRemove(Item item, int count)
    {
        if (CheakCorrectItem(item))
        {
            GetItemsCount(count);
        }
        else
        {
            throw new ArgumentException("Try get wrong item");
        }
    }


    private void AddItemsCount(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException("Count under zero");

        Count += count;
    }

    private void GetItemsCount(int count)
    {
        if (Count < count)
            throw new ArgumentOutOfRangeException("Not enough items count to remove");

        if (count < 0)
            throw new ArgumentOutOfRangeException("Try to collect zero items count");

        Count -= count;
    }
}
