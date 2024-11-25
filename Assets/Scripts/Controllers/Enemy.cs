using UnityEngine;

using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamageble
{
    private const float MinVectorValue = -1f; 
    private const float MaxVectorValue = 1f;

    private float _changeDirectionTime;
    
    private Mover _mover;
    private Health _health;

    private bool _wasInit;
    private float _currentTime;

    private LayerMask _mask;
    private float _damage;

    public void Init(float changeDirectionTime, Mover mover, Health health, LayerMask mask, float damage)
    {
        _currentTime = changeDirectionTime;

        _mover = mover;
        _changeDirectionTime = changeDirectionTime;
        _wasInit = true;

        _health = health;
        _damage = damage;
        _mask = mask;
    }

    public Stat<float> Health => _health.CurrentHealth;

    void Update()
    {
        if (_wasInit == false)
            return;

        _currentTime += Time.deltaTime;
        
        if ( _currentTime >= _changeDirectionTime)
        {
            _currentTime = 0;
            ChangeDirection();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((_mask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            IDamageble enemy = collision.gameObject.GetComponent<IDamageble>();
            if (enemy != null)
            {
                enemy.Remove(_damage);
            }
        }
    }

    public Rigidbody GetRigidbody() => GetComponent<Rigidbody>();
    
    public void Add(float health)
    {
        _health.Add(health);
    }

    public void Remove(float damage)
    {
        _health.Remove(damage);
    }

    private void ChangeDirection()
    {
        Vector3 newDirection = GetRandomVectorWithoutY();
        _mover.MoveToDirection(newDirection);
    }

    private Vector3 GetRandomVectorWithoutY()
    {
        float x = Random.Range(MinVectorValue, MaxVectorValue);
        float z = Random.Range(MinVectorValue, MaxVectorValue);

        return new Vector3 (x, 0, z);
    }

}
