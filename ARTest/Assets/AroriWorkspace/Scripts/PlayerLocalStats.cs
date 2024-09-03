using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocalStats : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float strength;
    [SerializeField] private float dexterity;
    [SerializeField] private float intelligence;

    public float Strength => strength;
    public float Dexterity => dexterity;
    public float Intelligence => intelligence;
    public float Health => health;
    public float MaxHealth => maxHealth;
}
