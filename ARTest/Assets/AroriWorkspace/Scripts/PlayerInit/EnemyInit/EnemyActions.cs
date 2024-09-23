using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActions : MonoBehaviour
{
    [SerializeField] private PlayerInitializer enemyInitializer;
    [SerializeField] private PlayerSkill[] enemySkills;
    [SerializeField] private Turn turn;

    private PlayerSkill[] sortedEnemySkills;
    private SpawnInitializer _spawnInitializer;
    private TurnBasedSystem _turnBasedSystem;
    private AnimationController _animationController;

    private void Awake()
    {
        _animationController = enemyInitializer.AnimationController;
        SortSkills();

        _animationController.OnEnemyReadyToUseSkill -= OnEnemyReadyToUseSkill;
        _animationController.OnEnemyReadyToUseSkill += OnEnemyReadyToUseSkill;
        enemyInitializer.OnInitializesConnection -= OnInitializesConnection;
        enemyInitializer.OnInitializesConnection += OnInitializesConnection;
    }

    private void OnEndEnemyTurn()
    {
        _turnBasedSystem.ChangeTurn(turn);
    }

    private void OnInitializesConnection()
    {
        _spawnInitializer = enemyInitializer.SpawnInitializer;

        _spawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        _spawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnImageTracked()
    {
        _turnBasedSystem = _spawnInitializer.TurnBasedSystem;
        _turnBasedSystem.OnEnemyTurn -= OnEnemyTurn;
        _turnBasedSystem.OnEnemyTurn += OnEnemyTurn;
    }
    private void OnEnemyReadyToUseSkill()
    {
        RealizeEnemyTurn();
    }

    private void OnEnemyTurn()
    {
        RealizeEnemyTurn();
    }

    private void SortSkills()
    {
        sortedEnemySkills = (PlayerSkill[])enemySkills.Clone();
        Array.Sort(sortedEnemySkills, (a, b) => a.TotalCost.CompareTo(b.TotalCost));
        Array.Reverse(sortedEnemySkills);
    }

    public void RealizeEnemyTurn()
    {
        if (_spawnInitializer.HeroInitializer.Health.IsDead)
            return;

        for (int i = 0; i < sortedEnemySkills.Length; i++)
        {
            if (!sortedEnemySkills[sortedEnemySkills.Length - 1].IsAvaible)
            {
                _turnBasedSystem.ChangeTurn(turn);
                break;
            }

            if (sortedEnemySkills[i].IsAvaible)
            {
                sortedEnemySkills[i].ActivateSkill();
                break;
            }
        }
    }
}
