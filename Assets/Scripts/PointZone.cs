using System;
using UnityEngine;

public class PointZone : MonoBehaviour
{
    [SerializeField] private InputHandler _inputController;
    [SerializeField] private GameObject _pointView;
    [SerializeField] private PlayerController _player;

    private NavigationMover _navigationMover;

    private void OnDestroy()
    {       
        _navigationMover.MovingChanged -= OnIsMoving;
        _navigationMover.PointChanged -= OnChangePoint;
    }

    public void Init(NavigationMover mover)
    {
        _navigationMover = mover;

        _pointView.SetActive(false);

        _navigationMover.MovingChanged += OnIsMoving;
        _navigationMover.PointChanged += OnChangePoint;

    }

    private void OnChangePoint(Vector3 vector)
    {
        _pointView.SetActive(true);
        transform.position = vector;
    }

    private void OnIsMoving(bool isMoving)
    {
        _pointView.SetActive(isMoving);
    }
}
