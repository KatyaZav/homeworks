using UnityEngine;

public class Shooter
{
    private float _bulletSpeed;
    private Bullet _bullet;
    private Transform _shootPoint;

    private LayerMask _enemyMask;
    private float _damage;
        
    public Shooter(Bullet bullet, float speed, Transform shootPoint, LayerMask layerMask, float damage)
    {
        _bullet = bullet;
        _bulletSpeed = speed;
        _shootPoint = shootPoint;
        _enemyMask = layerMask;
        _damage = damage;
    }

    public void Shoot()
    {
        Bullet bullet = GameObject.Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
        bullet.Launch(_bulletSpeed, _damage, _enemyMask);
    }
}
