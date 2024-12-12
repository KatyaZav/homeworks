using UnityEngine.UI;
using UnityEngine;
using System;

public class ValueView : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;

    private Currency _currency;
    
    public void Init(Currency curency, ValueConfig config)
    {
        _image.color = config.ImageColor;

        _currency = curency;
        _currency.Value.Changed += OnValueChange;

        OnValueChange(_currency.Value.Value);
    }

    private void OnDisable()
    {
        _currency.Value.Changed -= OnValueChange;        
    }
    
    private void OnValueChange(int value)
    {
        _text.text = value.ToString();
    }
}
