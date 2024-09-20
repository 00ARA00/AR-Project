using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn
{
    PlayerTurn,
    EnemyTurn,
    NewRound
}

public class TurnBasedSystem : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private UISystem _uISystem;
    
    public event Action OnEnemyTurn;

    private PlayerInitializer _heroInitializaer;
    private PlayerInitializer _enemyInitializaer;

    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;

        spawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        spawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnImageTracked()
    {
        _heroInitializaer = spawnInitializer.HeroInitializer;
        _enemyInitializaer = spawnInitializer.EnemyInitializer;
    }

    private void PlayerTurn()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableBattleLayout();
    }

    private void EnemyTurn()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableEnemyTurnLyout();
        OnEnemyTurn?.Invoke();
    }

    private void StartNewRound()
    {
        _heroInitializaer.Stats.SetAttributes(0,0,0);
        _enemyInitializaer.Stats.SetAttributes(0,0,0);

        _uISystem.DisableAllUI();
        _uISystem.EnableStatsRollLayout();
    }

    public void ChangeTurn(Turn turn)
    {
        RealizeTurn(turn);
    }

    private void RealizeTurn(Turn turn)
    {
        switch (turn)
        {
            case Turn.PlayerTurn:
                PlayerTurn();
                break;

            case Turn.EnemyTurn:
                EnemyTurn();
                break;

            case Turn.NewRound:
                StartNewRound();
                break;
        }
    }
}
