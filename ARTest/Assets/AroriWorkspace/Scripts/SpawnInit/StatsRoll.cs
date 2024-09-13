using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsRoll : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;
    [SerializeField] private int minimumDiceRoll;
    [SerializeField] private int maximumDiceRoll;


    private UISystem _uISystem;
    private PlayerLocalStats _playerLocalStats;
    private System.Random _random;


    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;
        _random = spawnInitializer.SpawnResources.Random;

        _uISystem.OnRollDicesButtonClick -= OnRollDicesButtonClick;
        _uISystem.OnRollDicesButtonClick += OnRollDicesButtonClick;

        spawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        spawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnRollDicesButtonClick()
    {
        float strenght = _random.Next(minimumDiceRoll, maximumDiceRoll);
        float dexterity = _random.Next(minimumDiceRoll, maximumDiceRoll);
        float intelligence = _random.Next(minimumDiceRoll, maximumDiceRoll);

        _playerLocalStats.SetAttributes(strenght, dexterity, intelligence);
    }

    private void OnImageTracked()
    {
        _playerLocalStats = spawnInitializer.HeroInitializer.Stats;
    }
}
