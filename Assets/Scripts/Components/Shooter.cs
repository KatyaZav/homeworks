using UnityEngine;

public class Shooter
{
    private float _bulletSpeed;
    private Bullet _bullet;
    private Transform _shootPoint;
        
    public Shooter(Bullet bullet, float speed, Transform shootPoint)
    {
        _bullet = bullet;
        _bulletSpeed = speed;
        _shootPoint = shootPoint;
    }

    public void Shoot()
    {
        Bullet bullet = GameObject.Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
        bullet.Launch(_bulletSpeed);
    }
}
