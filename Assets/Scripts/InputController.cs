using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    public event Action<Vector3> LeftMouseClicked;

    private Ray CameraRay => Camera.main.ScreenPointToRay(Input.mousePosition);

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            var position = GetMouseWorldPosition();
            LeftMouseClicked?.Invoke(position);
        }
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
