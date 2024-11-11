using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] GameObject _ex;

    public void Explode(Vector3 position)
    {
        _ex.transform.position = position;
        var objects = Physics.OverlapSphere(position, _radius, _layerMask.value);

        foreach (var obj in objects)
        {
            if (obj.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce((obj.transform.forward - transform.position) * _force, ForceMode.Impulse);
            }
        }
    }
}
