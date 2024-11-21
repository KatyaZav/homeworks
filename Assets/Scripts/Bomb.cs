using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _activateTime = 3f;
    [SerializeField] private float _radius;
    [SerializeField] private AudioComponent _audioComponent;

    [SerializeField] private AudioClip _tikClip, _destroyClip;
    
    private bool _isActivate = false;

    void Update()
    {
        if (_isActivate)
            return;

        var collider = GetDamagebleItemsInZone();
        if (collider.Count == 0)
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

    private List<IDamagable> GetDamagebleItemsInZone()
    {      
        var items = Physics.OverlapSphere(transform.position, _radius);
        List<IDamagable> result = new List<IDamagable>();

        foreach (var item in items)
        {
            var damagable = item.GetComponent<IDamagable>();

            if (damagable != null)
                result.Add(damagable);
        }

        return result;
    }

    private IEnumerator Timer(float time)
    {
        _audioComponent.SetSoundLoop(_tikClip);
        _isActivate = true;
        var currentTime = time;

        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }

        _audioComponent.Stop();
        _audioComponent.MakeNewSound(_destroyClip);

        var colliders = GetDamagebleItemsInZone();
        if (colliders.Count > 0)
        {
            foreach (var collider in colliders)
            {
                collider.TakeDamage(_damage);
            }
        }

        Destroy(gameObject);
    }
}
