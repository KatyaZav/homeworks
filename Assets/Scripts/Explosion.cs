using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] ParticleSystem _particles;

    public void Explode(Vector3 position)
    {
        _particles.transform.position = position;
        _particles.Play();

        var objects = Physics.OverlapSphere(position, _radius, _layerMask.value);

        foreach (var obj in objects)
        {
            if (obj.TryGetComponent(out IThrowable explosion))
            {
                explosion.AddForce((obj.transform.position - position).normalized * _force);
            }
        }
    }
}
