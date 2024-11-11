using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private const int _leftMouse = 0;
    private const int _rightMouse = 1;

    [SerializeField] Explosion _exlode;

    private IDragable _dragableObject;
    
    private Ray CameraRay => Camera.main.ScreenPointToRay(Input.mousePosition);
    private Plane DragPlane => new Plane(Camera.main.transform.forward, transform.position);
    
    void Update()
    {
        if (Input.GetMouseButtonDown(_rightMouse))
        {
            if (Physics.Raycast(CameraRay, out var hit))
            { 
                Vector3 fingerPosition = hit.point;
                _exlode.Explode(fingerPosition);
            }
        }
    }  

}
