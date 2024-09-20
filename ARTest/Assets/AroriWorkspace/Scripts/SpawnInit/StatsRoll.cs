using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsRoll : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    [SerializeField] private int minimumDiceRoll;
    [SerializeField] private int maximumDiceRoll;

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
        float strenght = _random.Next(minimumDiceRoll, maximumDiceRoll);
        float dexterity = _random.Next(minimumDiceRoll, maximumDiceRoll);
        float intelligence = _random.Next(minimumDiceRoll, maximumDiceRoll);

        _playerLocalStats.SetAttributes(strenght, dexterity, intelligence);
    }
}
