using UnityEngine;

public interface IDragable
{
    public void OnRaise();
    public void OnDrag(Vector3 position);
    public void OnDrop();
    public Vector3 LocalTransform { get; }
}
