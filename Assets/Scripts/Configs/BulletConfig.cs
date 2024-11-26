using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig", order = 1)]
public class BulletConfig : ScriptableObject
{
    [field: SerializeField] public Bullet BulletPrefab { get; private set; }
    [field: SerializeField] public LayerMask EnemyMask { get; private set; }
    [field: SerializeField] public float BulletSpeed { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }

}
