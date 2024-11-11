using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private const int _leftMouse = 0;
    private const int _rightMouse = 1;

    [SerializeField] Explosion _exlode;

    private IDragable _dragableObject;
    
    private Ray CameraRay => Camera.main.ScreenPointToRay(Input.mousePosition);
    private Plane DragPlane(Vector3 itemTransform) => new Plane(Camera.main.transform.forward, itemTransform);
    
    void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouse))
        {
            OnLeftMouseDown();
        }

        if (Input.GetMouseButtonUp(_leftMouse) && _dragableObject != null)
        {
            _dragableObject.OnDrop();
            _dragableObject = null;
        }

        if (Input.GetMouseButton(_leftMouse) && _dragableObject != null)
        {
            OnLeftMouse();
        }

        if (Input.GetMouseButtonDown(_rightMouse))
        {
            OnRightMouseDown();
        }
    }  

    private void OnLeftMouseDown()
    {
        if (Physics.Raycast(CameraRay, out var hit))
        {
            var touchedObject = hit.collider.gameObject;

            if (touchedObject.TryGetComponent(out IDragable dragObject))
            {
                _dragableObject = dragObject;
                dragObject.OnRaise();
            }
        }
    }

    private void OnRightMouseDown()
    {
        if (Physics.Raycast(CameraRay, out var hit))
        {
            Vector3 fingerPosition = hit.point;
            _exlode.Explode(fingerPosition);
        }
    }

    private void OnLeftMouse()
    {
        if (DragPlane(_dragableObject.LocalTransform).Raycast(CameraRay, out float enter))
        {
            Vector3 fingerPosition = CameraRay.GetPoint(enter);
            _dragableObject.OnDrag(fingerPosition);
        }
    }
}
