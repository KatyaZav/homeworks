using System;
using UnityEngine;

public class InputController : MonoBehaviour, IInitable
{
    private const int LeftMouseButton = 0;

    public event Action<Vector3> LeftMouseClicked;
    
    private bool _isInit;
    private Ray CameraRay => Camera.main.ScreenPointToRay(Input.mousePosition);

    private void Update()
    {
        if (_isInit == false)
            return;

        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            var position = GetMouseWorldPosition();
            LeftMouseClicked?.Invoke(position);
        }
    }
    public void Init()
    {
        _isInit = true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        if (Physics.Raycast(CameraRay, out var hit))
        {
            return hit.point;
        }

        Debug.LogError("not found mouse position");
        return Vector3.zero;
    }

}
