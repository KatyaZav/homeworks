using System;
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
    
    private Health _health;
    private NavigationMover _navigationMover;
    private AnimatorView _animatorView;
    private bool _previousState;
    private bool isDead;

    private void Update()
    {
        if (isDead)
            return;

        if (_navigationMover.HasPath == false && _previousState == true)
        {
            PlayerStoped?.Invoke();

            _previousState = false;
            _navigationMover.SetIsMoving(false);
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

        _previousState = true;
        _navigationMover.SetIsMoving(true);
        _navigationMover.SetPoint(vector);
    }
}
