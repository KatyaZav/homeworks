using UnityEngine;
using UnityEngine.UI;

public class SliderTimerUI : BaseTimerUI
{
    [SerializeField] private Slider _slider;

    protected override void OnInit()
    {
        _slider.maxValue = _maxValue;
    }

    protected override void OnValueChange(float value)
    {
        _slider.value = value;
    }
}
