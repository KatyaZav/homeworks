using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private LayerMask _mask;
    private float _damage;

    public void Launch(float speed, float damage, LayerMask mask)
    {        
        _damage = damage;
        _mask = mask;
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((_mask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            IDamageble enemy = collision.gameObject.GetComponent<IDamageble>();
            if (enemy != null)
            {
                enemy.Remove(_damage);
                Destroy(gameObject);
            }
        }
    }
}
