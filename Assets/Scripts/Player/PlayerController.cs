using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IInitable
{
    private readonly int FullValue = 1, ZeroValue = 0;

    public event Action PlayerStoped;

    [Header("Components")]
    [SerializeField] private InputController _inputController;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;

    [Header("Settings")]
    [SerializeField] private float _maxHealth;
    [SerializeField, Range(0, 1)] private float _layerChangeValue = 0.3f;

    [SerializeField] private float _waitTime = 10f;
    [SerializeField] private float _patrolRadius = 3f;
    [SerializeField] private float _timeToChangeLocation = 2f;

    private Coroutine _chaousCoroutine = null;
    
    private Health _health;
    private NavigationMover _navigationMover;
    private AnimatorView _animatorView;

    private IState _currentMoving, _pointMoving, _randomMoving;

    private bool isDead;
    
    private float _currentTime = 0;

    private void Update()
    {
        if (isDead)
            return;

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

        if (_navigationMover.HasPath == false)
        {
            PlayerStoped?.Invoke();
        }
        
        _animatorView.SetRunning(_navigationMover.isGoing);
    }

    private void OnDestroy()
    {
        _inputController.LeftMouseClicked -= OnLeftMouseClicked;
        _health.HealthChanged -= OnHealthChanged;        
    }

    public void Init()
    {
        _navigationMover = new NavigationMover(_navMeshAgent);
        _animatorView = new AnimatorView(_animator);
        _health = new Health(_maxHealth);

        _pointMoving = new PointMoving(_navigationMover);
        _randomMoving = new RandomMoving(_navigationMover, _patrolRadius, _timeToChangeLocation, transform);
        ChangeState(_pointMoving);
        
        _navigationMover.SetIsMoving(false);

        _inputController.LeftMouseClicked += OnLeftMouseClicked;
        _health.HealthChanged += OnHealthChanged;        
    }

    public void TakeDamage(float damage)
    {
        _health.RemoveHealth(damage);
        _animatorView.GetDamage();

        print(_health.CurretnHealth);
    }

    private void OnHealthChanged(float health)
    {
        if ((_health.CurretnHealth / _maxHealth) < _layerChangeValue)
        {
            _animatorView.SetEnjureLayerWeight(FullValue);
        }
        else
        {
            _animatorView.SetEnjureLayerWeight(ZeroValue);
        }

        if (health == 0)
        {
            isDead = true;
            _animatorView.Dead();
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
