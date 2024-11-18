using System;

public class Health
{
    public Action<float> HealthChanged;

    private float _currentHealth;
    private float _maxHealth;

    public Health(float maxHealth)
    {
        _currentHealth = maxHealth;
        _maxHealth = maxHealth;
    }

    public float CurretnHealth => _currentHealth;

    public void RemoveHealth(float health)
    {
        _currentHealth -= health;
       
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            HealthChanged?.Invoke(_currentHealth);
        }
    }

    public void AddHealth(float health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}
