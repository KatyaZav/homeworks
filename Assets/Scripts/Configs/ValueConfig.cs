using UnityEngine;

[CreateAssetMenu(fileName = "ValueConfig", menuName = "Configs/ValueConfig", order = 1)]
public class ValueConfig : ScriptableObject
{
    [field: SerializeField] public int OriginalValue { get; private set; } = 0;
    [field: SerializeField] public CurrenceType Type { get; private set; }
    [field: SerializeField] public Color ImageColor {  get; private set; } = Color.white;
}
