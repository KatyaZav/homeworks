using UnityEngine;

using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private const float MinVectorValue = -1f; 
    private const float MaxVectorValue = 1f;

    private float _changeDirectionTime;
    
    private Mover _mover;

    private bool _wasInit;
    private float _currentTime;

    public void Init(float changeDirectionTime, Mover mover)
    {
        _currentTime = changeDirectionTime;

        _mover = mover;
        _changeDirectionTime = changeDirectionTime;
        _wasInit = true;

    }

    // Update is called once per frame
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

    public Rigidbody GetRigidbody() => GetComponent<Rigidbody>();

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
