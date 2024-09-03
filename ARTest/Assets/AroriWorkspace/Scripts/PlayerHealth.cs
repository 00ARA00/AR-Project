using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    [SerializeField] private PlayerInitializer playerInitializer;

    public float Health { get; private set; }
    public float MaxHealth { get; private set; }
    public bool IsDead { get; private set; }

    private void Awake()
    {
        Health = playerInitializer.Stats.Health;
        MaxHealth = playerInitializer.Stats.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (IsDead)
            return;

        Health -= damage;

        if (Health <= 0)
        {
            IsDead = true;
        }
    }

    public float GetValue()
    {
        return Health;
    }
}
