using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocalStats : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float strengthAttribute;
    [SerializeField] private float dexterityAttribute;
    [SerializeField] private float intelligentAttribute;

    public float StrengthAttribute => strengthAttribute;
    public float DexterityAttribute => dexterityAttribute;
    public float IntelligentAttribute => intelligentAttribute;
    public float Health => health;
    public float MaxHealth => maxHealth;

    public event Action OnAttributesChanged;

    public (float, float, float) GetAttributes()
    {
        float strength = strengthAttribute;
        float dexterity = dexterityAttribute;
        float intelligent = intelligentAttribute;

        return (strength, dexterity, intelligent);
    }

    public void SetAttributes(float strength, float dexterity, float intelligent)
    {
        strengthAttribute = strength;
        dexterityAttribute = dexterity;
        intelligentAttribute = intelligent;

        OnAttributesChanged?.Invoke();
    }
}
