using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    private IDragable _dragableObject;

    public Vector3 ItemTransform => _dragableObject.LocalTransform;
    public bool IsDrag => _dragableObject != null;

    public void Raise(IDragable dragableObject)
    {
        _dragableObject = dragableObject;
        _dragableObject.OnRaise();
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
}
