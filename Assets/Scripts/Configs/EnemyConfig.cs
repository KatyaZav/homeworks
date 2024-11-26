using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig", order = 1)]
public class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public Enemy EnemyPrefab { get; private set; }
    [field: SerializeField] public LayerMask EnemyMask { get; private set; }
    [field: SerializeField] public float ChangeDirectionTime { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }

}
