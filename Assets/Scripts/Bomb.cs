using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _activateTime = 3f;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private bool _isActivate = false;
    private Collider[] Player => Physics.OverlapSphere(transform.position, _radius, _layerMask.value);

    void Update()
    {
        if (_isActivate)
            return;

        var collider = Player;
        if (collider.Length == 0)
            return;

        _isActivate = true;
        StartCoroutine(Timer(_activateTime));
    }

    private void OnDrawGizmos()
    {
        var color = Color.red;
        color.a = 0.2f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, _radius);
    }

    private IEnumerator Timer(float time)
    {
        _isActivate = true;
        var currentTime = time;

        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }

        var colliders = Player;
        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                collider.gameObject.GetComponent<PlayerController>().TakeDamage(_damage);
            }
        }

        Destroy(gameObject);
    }
}
