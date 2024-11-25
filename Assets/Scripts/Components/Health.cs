using UnityEngine;

public class Health
{
    private const int MinValue = 0;
    private float _currentHealth, _maxHealth;

    public Health(float maxHealth)
    {
        _currentHealth = maxHealth;
        _maxHealth = maxHealth;
    }

    public float CurrentHealth => _currentHealth;

    public void Add(float health)
    {
        float temp = _currentHealth + health;
        _currentHealth = Mathf.Min(temp, _maxHealth);
    } 

    public void Remove(float damage)
    {
        float temp = _currentHealth - damage;
        _currentHealth = Mathf.Max(temp, MinValue);
    }
}
