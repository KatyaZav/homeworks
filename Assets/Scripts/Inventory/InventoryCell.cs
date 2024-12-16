using System;

public class InventoryCell
{
    public InventoryCell()
    {
    }

    public InventoryCell(Item items, int count)
    {
        Item = items;
        Count = count;
    }

    public int Id { get; private set; }
    public int Count { get; private set; }
    
    private Item Item { get; set; }

    public bool CheakCorrectItem(Item item) => item == Item;

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

    public Item TryCollect(Item item, int count)
    {
        if (CheakCorrectItem(item))
        {
            return CollectItemsCount(count);
        }
        else
        {
            throw new ArgumentException("Try get wrong item");
        }
    }

    public Item CollectItemsCount(int count)
    {
        if (Count < count)
            throw new ArgumentOutOfRangeException("Not enough items count to remove");

        if (count < 0)
            throw new ArgumentOutOfRangeException("Try to collect zero items count");

        Count -= count;
        return Item;
    }

    private void AddItemsCount(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException("Count under zero");

        Count += count;
    }

}
