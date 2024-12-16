using System.Collections.Generic;
using System.Linq;
using System;

public class Inventory
{
    public const int ZeroValue = 0;

    private List<InventoryCell> _items = new();
    private int _maxSize;

    public Inventory(List<InventoryCell> items, int maxSize)
    {
        _items = items;
        _maxSize = maxSize;
    }

    public IReadOnlyList<InventoryCell> Items => _items; 
    public int CurrentSize => _items.Sum(item => item.Count);
    
    public bool CanAdd(int count) => CurrentSize + count <= _maxSize;
    public bool TryGetCellByItemId(int id) => _items.FirstOrDefault(item => item.Id == id) != null;

    private InventoryCell GetCellByItemID(int id) => _items.First(item => item.Id == id);

    public void Add(Item item, int count)
    {
        if (CanAdd(count) == false)
            throw new Exception("Inventory are full");

        if (TryGetCellByItemId(item.Id))
        {
            GetCellByItemID(item.Id).TryAdd(item, count);
        }
        else
        {
            _items.Add(new InventoryCell(item, count)); 
        }
    }

    public Item GetItemsBy(int id, int count)
    {
        if (TryGetCellByItemId(id))
        {
            Item item = GetCellByItemID(id).CollectItemsCount(count);
            return item;
        }
        else
        {
            throw new ArgumentNullException($"Inventory has no item with id {id}");
        }
    }
}