using UnityEngine;

public class Item : MonoBehaviour, IDragable, IThrowable
{
    [SerializeField] private float _maxScale;
    [SerializeField] private float _upPosition;
    [SerializeField] private Rigidbody _rigidbody;
    
    private float _minScale;
    private float _normalPosition;

    public Vector3 LocalTransform => transform.position;

    private void Start()
    {
        _minScale = transform.localScale.x;
        _normalPosition = transform.localPosition.y;
    }

    public void OnDrag(Vector3 position)
    {
        position.y = _upPosition;
        transform.position = position;
    }

    public void OnDrop()
    {
        _rigidbody.isKinematic = false;
        transform.localScale = _minScale * Vector3.one;
    }

    public void OnRaise()
    {
        _rigidbody.isKinematic = true;

        transform.localScale = _maxScale * Vector3.one;

        var newPosition = transform.position;
        newPosition.y = _upPosition;
        transform.position = newPosition; 
    }

    public void AddForce(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
