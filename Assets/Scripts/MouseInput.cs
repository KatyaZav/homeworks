using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private const int _leftMouse = 0;
    private const int _rightMouse = 1;

    [SerializeField] private Explosion _exlode;
    
    private DragManager _drag;
    
    private Ray CameraRay => Camera.main.ScreenPointToRay(Input.mousePosition);
    private Plane DragPlane(Vector3 itemTransform) => new Plane(Camera.main.transform.forward, itemTransform);

    private void Start()
    {
        _drag = new DragManager();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouse))
        {
            var item = GetTouchedGameObject();
            _drag.TryRaise(item);
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
            Vector3 fingerPosition = GetMouseFloorPosition();
            _exlode.Explode(fingerPosition); 
        }
    }  

    private GameObject GetTouchedGameObject()
    {
        if (Physics.Raycast(CameraRay, out var hit))
        {
            return hit.collider.gameObject;            
        }

        return null;
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

    private Vector3 GetMouseFloorPosition()
    {
        if (Physics.Raycast(CameraRay, out var hit))
        {
            return hit.point;            
        }

        Debug.LogError("Camera ray not collide");
        return Vector3.zero;
    }
}
