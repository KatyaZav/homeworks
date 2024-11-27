using UnityEngine;

[CreateAssetMenu(fileName = "ValueConfig", menuName = "Configs/ValueConfig", order = 1)]
public class ValueConfig : ScriptableObject
{
    [field: SerializeField] public Color ImageColor {  get; private set; } = Color.white;
}
