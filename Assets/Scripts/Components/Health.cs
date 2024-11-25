using UnityEngine;

public class Health
{
    private const int MinValue = 0;

    private float _maxHealth;

    public Health(float maxHealth)
    {
        CurrentHealth = new Stat<float>(maxHealth);
        _maxHealth = maxHealth;
    }

    public Stat<float> CurrentHealth { get; private set; }

    public void Add(float health)
    {
        float temp = CurrentHealth.Value + health;
        CurrentHealth.Value = Mathf.Min(temp, _maxHealth);
    } 

    public void Remove(float damage)
    {
        float temp = CurrentHealth.Value - damage;
        CurrentHealth.Value = Mathf.Max(temp, MinValue);
    }
}
