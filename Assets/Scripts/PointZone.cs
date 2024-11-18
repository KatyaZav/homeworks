using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private GameObject _pointView;
    [SerializeField] private PlayerController _player;

    private void OnDestroy()
    {
        _inputController.LeftMouseClicked -= SetPoint;        
        _player.PlayerStoped -= DisactivatePoint;
    }

    public void Init()
    {
        _inputController.LeftMouseClicked += SetPoint;
        _player.PlayerStoped += DisactivatePoint;

        _pointView.SetActive(false);
    }

    private void SetPoint(Vector3 vector)
    {
        _pointView.SetActive(true);
        transform.position = vector;
    }

    private void DisactivatePoint()
    {
        _pointView.SetActive(false);
    }

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
