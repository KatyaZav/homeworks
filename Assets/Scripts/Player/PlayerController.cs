using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    
    private NavigationMover _navigationMover;
    private AnimatorView _animatorView;

    public void Init()
    {
        _navigationMover = new NavigationMover(_navMeshAgent);
        _animatorView = new AnimatorView(_animator);

        _inputController.LeftMouseClicked += OnLeftMouseClicked;
    }

    private void OnLeftMouseClicked(Vector3 vector)
    {
        _navigationMover.StopMoving(false);
        _navigationMover.SetPoint(vector);
    }

    void Start()
    {
        Init();
    }
}
