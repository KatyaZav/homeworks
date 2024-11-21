using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IInitable
{
    //public event Action Stoped;
    public event Action<float> Damaged;
    public event Action<bool> Stoped;

    [Header("Components")]
    [SerializeField] private InputController _inputController;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private PointZone _pointZone;

    [Header("Settings")]
    [SerializeField] private float _maxHealth;

    [SerializeField] private float _waitTime = 10f;
    [SerializeField] private float _patrolRadius = 3f;
    [SerializeField] private float _timeToChangeLocation = 2f;

    private Coroutine _chaousCoroutine = null;
    
    private Health _health;
    private NavigationMover _navigationMover;

    private IState _currentMoving, _pointMoving, _randomMoving;

    private bool isDead;
    private bool _previousState;
    private float _currentTime = 0;

    public float MaxHealth => _maxHealth;
    public bool IsGoing => _navigationMover.isGoing;

    private void Update()
    {
        if (isDead)
            return;

        if (_navigationMover.HasPath != _previousState)
        {
            _previousState = _navigationMover.HasPath;
            Stoped?.Invoke(_navigationMover.HasPath == false);
        }

        _currentMoving.Update();

        if (_navigationMover.HasPath == false && _currentMoving != _randomMoving)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _waitTime && _currentMoving != _randomMoving)
            {
                print("player bored");
                ChangeState(_randomMoving);
            }
        }
    }

    private void OnDestroy()
    {
        _inputController.LeftMouseClicked -= OnLeftMouseClicked;
        _health.HealthChanged -= OnHealthChanged;        
    }

    public void Init()
    {
        _navigationMover = new NavigationMover(_navMeshAgent);
        _health = new Health(_maxHealth);

        _pointMoving = new PointMoving(_navigationMover);
        _randomMoving = new RandomMoving(_navigationMover, _patrolRadius, _timeToChangeLocation, transform);
        ChangeState(_pointMoving);
        
        _navigationMover.SetIsMoving(false);
        _pointZone.Init(_navigationMover);

        _inputController.LeftMouseClicked += OnLeftMouseClicked;
        _health.HealthChanged += OnHealthChanged;        
    }

    public void TakeDamage(float damage)
    {
        _health.RemoveHealth(damage);
        Damaged?.Invoke(_health.CurretnHealth);

        print(_health.CurretnHealth);
    }

    private void OnHealthChanged(float health)
    {      
        if (health == 0)
        {
            isDead = true;
        }
    }

    private void OnLeftMouseClicked(Vector3 vector)
    {
        if (isDead)
            return;

        ChangeState(_pointMoving);
        _currentMoving.SetPoint(vector);

        _currentTime = 0;
    }

    private void ChangeState(IState newState)
    {
        _currentMoving?.Exit();
        _currentMoving = newState;
        _currentMoving.Enter();
    }
}
