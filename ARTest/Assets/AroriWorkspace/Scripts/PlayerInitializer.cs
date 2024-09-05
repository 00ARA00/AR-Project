using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerStrengthAttribute playerStrengthAttribute;
    [SerializeField] private PlayerDexterityAttribute playerDexterityAttribute;
    [SerializeField] private PlayerIntelligenceAttribute playerIntelligenceAttribute;

    [SerializeField] private PlayerLocalStats playerLocalStats;

    private SpawnInitializer _spawnInitializer;

    public event Action OnInitializesConnection;
    public PlayerStrengthAttribute Strength => playerStrengthAttribute;
    public PlayerDexterityAttribute Dexterity => playerDexterityAttribute;
    public PlayerIntelligenceAttribute Intelligence => playerIntelligenceAttribute;
    public PlayerHealth Health => playerHealth;
    public PlayerLocalStats Stats => playerLocalStats;
    public SpawnInitializer SpawnInitializer => _spawnInitializer;

    public void InitializeSI(SpawnInitializer spawnInitializer)
    {
        _spawnInitializer = spawnInitializer;
        OnInitializesConnection?.Invoke();
    }
}
