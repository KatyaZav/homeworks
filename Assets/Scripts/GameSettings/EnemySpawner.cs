using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
{
    private Transform _spawnPoint;
    private float _waitTime;
    
    private Enemy _enemy;
    private float _changeDirectionTime;
    private float _enemySpeed;
    private float _health;
    private float _damage;
    private LayerMask _layerMask;
    private MonoBehaviour _root;
    public static ListStat<Enemy> ListEnemy {  get; private set; }

    public EnemySpawner(EnemyConfig enemyConfig, Transform spawnPoint, float waitTime, MonoBehaviour root)
    {
        _waitTime = waitTime;
        _spawnPoint = spawnPoint;
        _root = root;

        _enemy = enemyConfig.EnemyPrefab;
        _changeDirectionTime = enemyConfig.ChangeDirectionTime;
        _enemySpeed = enemyConfig.Speed;
        _health = enemyConfig.Health;
        _damage = enemyConfig.Damage;
        _layerMask = enemyConfig.EnemyMask;
    }

    public void StartSpawning()
    {
        ListEnemy ??= new ListStat<Enemy>(new List<Enemy>());

        _root.StartCoroutine(SpawnLogic());
    }

    private IEnumerator SpawnLogic()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_waitTime);
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = GameObject.Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);

        Mover mover = new Mover(enemy.GetRigidbody(), _enemySpeed);
        Health health = new Health(_health);
        
        enemy.Init(_changeDirectionTime, mover, health, _layerMask, _damage);

        ListEnemy.Add(enemy);
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;

        ListEnemy.Remove(enemy);
    }
}
