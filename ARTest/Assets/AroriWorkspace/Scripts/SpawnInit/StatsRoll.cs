using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsRoll : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    [SerializeField] private int minimumStrength;
    [SerializeField] private int maximumStrength;
    [SerializeField] private int minimumDexterity;
    [SerializeField] private int maximumDexterity;
    [SerializeField] private int minimumIntelligence;
    [SerializeField] private int maximumIntelligence;

    [SerializeField] private Turn turn;
    [SerializeField] private bool enemyRoll;

    private UISystem _uISystem;
    private PlayerLocalStats _playerLocalStats;
    private System.Random _random;
    private TurnBasedSystem _turnBasedSystem;


    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;
        _random = spawnInitializer.SpawnResources.Random;
        _turnBasedSystem = spawnInitializer.TurnBasedSystem;

        if (!enemyRoll)
        {
            _uISystem.OnRollStatsButtonClick -= OnRollDicesButtonClick;
            _uISystem.OnRollStatsButtonClick += OnRollDicesButtonClick;
        }

        if (enemyRoll)
        {
            _uISystem.OnEndTurnButtonClick -= OnEndTurnButtonClick;
            _uISystem.OnEndTurnButtonClick += OnEndTurnButtonClick;
        }

        spawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        spawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnEndTurnButtonClick()
    {
        RandomizeStats();
        _turnBasedSystem.ChangeTurn(turn);
    }

    private void OnRollDicesButtonClick()
    {
        RandomizeStats();
        _turnBasedSystem.ChangeTurn(turn);
    }

    private void OnImageTracked()
    {
        if (!enemyRoll)
        {
            _playerLocalStats = spawnInitializer.HeroInitializer.Stats;
        }

        if (enemyRoll)
        {
            _playerLocalStats = spawnInitializer.EnemyInitializer.Stats;
        }
    }

    private void RandomizeStats()
    {
        float strenght = _random.Next(minimumStrength, maximumStrength);
        float dexterity = _random.Next(minimumDexterity, maximumDexterity);
        float intelligence = _random.Next(minimumIntelligence, maximumIntelligence);

        _playerLocalStats.SetAttributes(strenght, dexterity, intelligence);
    }
}
