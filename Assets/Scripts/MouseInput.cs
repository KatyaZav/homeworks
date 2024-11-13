using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private const int _leftMouse = 0;
    private const int _rightMouse = 1;

    [SerializeField] Explosion _exlode;
    [SerializeField] DragManager _drag;
    
    private Ray CameraRay => Camera.main.ScreenPointToRay(Input.mousePosition);
    private Plane DragPlane(Vector3 itemTransform) => new Plane(Camera.main.transform.forward, itemTransform);
    
    void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouse))
        {
            if (TryGetDragable(out var item))
                _drag.Raise(item);
        }

        if (Input.GetMouseButtonUp(_leftMouse) && _drag.IsDrag)
        {
            _drag.Drop();
        }

        if (Input.GetMouseButton(_leftMouse) && _drag.IsDrag)
        {
            var position = GetMousePosition(_drag.ItemTransform);
            _drag.Drag(position);
        }

        if (Input.GetMouseButtonDown(_rightMouse))
        {
            Explode();
        }
    }  
    
    private void Explode()
    {
        if (Physics.Raycast(CameraRay, out var hit))
        {
            Vector3 fingerPosition = hit.point;
            _exlode.Explode(fingerPosition);
        }
    }

    private bool TryGetDragable(out IDragable item)
    {
        if (Physics.Raycast(CameraRay, out var hit))
        {
            var touchedObject = hit.collider.gameObject;

            if (touchedObject.TryGetComponent(out IDragable dragObject))
            {
                item = dragObject;
                return true;
            }
        }

        item = null;
        return false;
    }

    private Vector3 GetMousePosition(Vector3 itemPosition)
    {
        if (DragPlane(itemPosition).Raycast(CameraRay, out float enter))
        {
            return CameraRay.GetPoint(enter);
        }

        Debug.LogError("Camera ray not collide");
        return Vector3.zero;
    }

    private Vector3 GetMouseDropPosition()
    {
        //if (DragPlane(_dragableObject.LocalTransform).Raycast(CameraRay, out float enter))
        if (Physics.Raycast(CameraRay, out var hit))
        {
            return hit.point;
            //Vector3 fingerPosition = CameraRay.GetPoint(enter);
            
        }

        Debug.LogError("Camera ray not collide");
        return Vector3.zero;
    }
}
