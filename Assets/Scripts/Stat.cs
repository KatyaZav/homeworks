using System;
using UnityEngine;
public class Stat<T> where T : IComparable
{
    public event Action<T> Changed;

    private T _value;

    public Stat(T value)
    {
        _value = value;
    }

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value; 
            
            _value = value;

            if (_value.CompareTo(oldValue) != 0)
            {
                Debug.Log("Changed to " + _value);
                Changed?.Invoke(_value);
            }
        }
    }
}
