using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour, IInitable
{
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

    private void Update()
    {
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

    private void OnHealthChanged(float obj)
    {
        if (_health.CurretnHealth / _maxHealth <= _layerChangeValue)
        {
            print("Смена анимации to injured");
        }
        else
        {
            print("animation change to normal");
        }
    }

    private void OnLeftMouseClicked(Vector3 vector)
    {
        _previousState = true;
        _navigationMover.SetIsMoving(true);
        _navigationMover.SetPoint(vector);
    }
}
