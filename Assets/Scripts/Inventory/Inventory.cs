using System.Collections.Generic;
using System.Linq;
using System;

public class Inventory
{
    public const int ZeroValue = 0;

    private List<Item> _items = new();
    private int _maxSize;

    public Inventory(List<Item> items, int maxSize)
    {
        _items = items;
        _maxSize = maxSize;
    }

    public List<Item> Items => _items;
    public int CurrentSize => _items.Sum(item => item.Count);
    public bool CanAdd(int count) => CurrentSize + count <= _maxSize;

    private Item GetItemById(int id) => _items.First(item => item.Id == id);

    public void Add(Item item)
    {
        if (CanAdd(item.Count) == false)
            throw new Exception("Inventory are full");

        Item newItem = GetItemById(item.Id);
        if (newItem != null)
        {
            newItem.Add(item.Count);
        }
        else
        {
            _items.Add(item);
        }
    }

    public Item GetItemsBy(int id, int count)
    {
        Item item = GetItemById(id);

        if (item == null)
            throw new NullReferenceException("Item not found");

        Item returnItem = new Item(id, count);
        item.Collect(count);

        if (item.Count == ZeroValue)
            _items.Remove(item);

        return returnItem;
    }
}