using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private IDragable _dragItem;

    void Start()
    {
        _dragItem = GetComponent<IDragable>();
    }

    private void OnMouseDown()
    {
        _dragItem.OnRaise();
    }

    private void OnMouseDrag()
    {
        Plane dragPlane = new Plane(Camera.main.transform.forward, transform.position);
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float enter = 0.0f;
        if (dragPlane.Raycast(camRay, out enter))
        {
            Vector3 fingerPosition = camRay.GetPoint(enter);
            fingerPosition.y = transform.position.y;
            _dragItem.OnDrag(fingerPosition);
        }
    }

    private void OnMouseUp()
    {
        _dragItem.OnDrop();
    }
}
