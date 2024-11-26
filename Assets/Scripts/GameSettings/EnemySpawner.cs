using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _changeDirectionTime;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _layerMask;

    public static ListStat<Enemy> ListEnemy {  get; private set; }

    public void Init()
    {
        ListEnemy ??= new ListStat<Enemy>(new List<Enemy>());

        StartCoroutine(SpawnLogic());
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
        Enemy enemy = Instantiate(_enemy, transform.position, transform.rotation);

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
