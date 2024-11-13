using UnityEngine;

public class DragManager
{
    private IDragable _dragableObject;

    public Vector3 ItemTransform => _dragableObject.LocalTransform;
    public bool IsDrag => _dragableObject != null;

    public bool TryRaise(GameObject touchedObject)
    {
        if (touchedObject == null)
            return false;

        if (touchedObject.TryGetComponent(out IDragable dragObject))
        {
            Raise(dragObject);
            return true;
        }

        return false;
    }


    public void Drop()
    {
        _dragableObject.OnDrop();
        _dragableObject = null;
    }

    public void Drag(Vector3 fingerPosition)
    {
        _dragableObject.OnDrag(fingerPosition);
    }
    private void Raise(IDragable dragableObject)
    {
        _dragableObject = dragableObject;
        _dragableObject.OnRaise();
    }
}
