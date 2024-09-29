using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn
{
    PlayerTurn,
    EnemyTurn,
    NewRound,
    EndGameWin,
    EndGameLose
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

        _heroInitializaer.Health.OnDeath -= OnDeath;
        _heroInitializaer.Health.OnDeath += OnDeath;

        _enemyInitializaer.Health.OnDeath -= OnDeath;
        _enemyInitializaer.Health.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        if (_heroInitializaer.Health.IsDead) { ChangeTurn(Turn.EndGameLose); }
        if (_enemyInitializaer.Health.IsDead) { ChangeTurn(Turn.EndGameWin); }
    }

    private void PlayerTurn()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableBattleLayout();
    }

    private void EnemyTurn()
    {
        _uISystem.DisableAllUI();
        _uISystem.DisableAllSkillButtons();
        _uISystem.EnableEnemyTurnLyout();
        OnEnemyTurn?.Invoke();
    }

    private void StartNewRound()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableStatsRollLayout();
        _uISystem.DisableAllSkillButtons();
    }

    private void EndGameWin()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableWinLayout();
        _heroInitializaer.AnimationController.PlayWinAnimation();
    }

    private void EndGameLose()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableLoseLayout();
        _enemyInitializaer.AnimationController.PlayWinAnimation();
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

            case Turn.EndGameWin:
                EndGameWin();
                break;

            case Turn.EndGameLose:
                EndGameLose();
                break;
        }
    }
}
