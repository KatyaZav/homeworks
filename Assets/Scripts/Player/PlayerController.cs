using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public event Action PlayerStoped;

    [SerializeField] private InputController _inputController;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    
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

    public void Init()
    {
        _navigationMover = new NavigationMover(_navMeshAgent);
        _animatorView = new AnimatorView(_animator);

        _inputController.LeftMouseClicked += OnLeftMouseClicked;
        _navigationMover.SetIsMoving(false);
    }

    private void OnLeftMouseClicked(Vector3 vector)
    {
        _previousState = true;
        _navigationMover.SetIsMoving(true);
        _navigationMover.SetPoint(vector);
    }

    void Start()
    {
        Init();
    }
}
