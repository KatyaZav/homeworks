using System;
using System.Collections.Generic;

public class ListStat<T>
{
    public event Action<List<T>> Added;
    public event Action<List<T>> Removed;

    private List<T> _value;

    public ListStat(List<T> value)
    {
        _value = value;
    }

    public List<T> ListValue;

    public void Add(T value)
    {
        _value.Add(value);

        Added?.Invoke(_value);
    }

    public void Remove(T value)
    {
        _value.Remove(value);

        Removed?.Invoke(_value);
    }
}
