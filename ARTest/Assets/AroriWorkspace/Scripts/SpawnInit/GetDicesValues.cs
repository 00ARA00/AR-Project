using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDicesValues : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    [SerializeField] private DiceStats strDice;
    [SerializeField] private DiceStats dexDice;
    [SerializeField] private DiceStats intDice;

    private bool _isCoroutineEnd;
    private bool _isMethodCalled;

    private UISystem _uiSystem;
    private TurnBasedSystem _turnBasedSystem;
    private PlayerInitializer _heroInitializer;

    private void Awake()
    {
        _turnBasedSystem = spawnInitializer.TurnBasedSystem;
        _uiSystem = spawnInitializer.UISystem;

        _uiSystem.OnEndTurnButtonClick -= OnEndTurnButtonClick;
        _uiSystem.OnEndTurnButtonClick += OnEndTurnButtonClick;

        spawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        spawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;

        spawnInitializer.UISystem.OnRollStatsButtonClick -= OnRollStatsButtonClick;
        spawnInitializer.UISystem.OnRollStatsButtonClick += OnRollStatsButtonClick;
    }

    private void OnEndTurnButtonClick()
    {
        ResetBools();
    }

    private void OnImageTracked()
    {
        _heroInitializer = spawnInitializer.HeroInitializer;
    }

    private void Update()
    {
        if (_isCoroutineEnd)
        {
            DicesCondition();
        }
    }

    private void OnRollStatsButtonClick()
    {
        StartCoroutine(WaitForDicesMove());
    }

    private IEnumerator WaitForDicesMove()
    {
        yield return new WaitForSeconds(1f);

        _isCoroutineEnd = true;
    }

    private void DicesCondition()
    {
        if (strDice.IsDiceStationary && dexDice.IsDiceStationary && intDice.IsDiceStationary)
        {
            StartCoroutine(WaitForSomeTime());
        }
        else
        {
            return;
        }
    }

    private void GetValues()
    {
        if (_turnBasedSystem.CurrentTurn == Turn.NewRound)
        {
            if (!_isMethodCalled)
            {
                _heroInitializer.Stats.AddAttributes(strDice.Side, dexDice.Side, intDice.Side);

                _isMethodCalled = true;
                _turnBasedSystem.ChangeTurn(Turn.PlayerTurn);
            }
            else
            {
                return;
            }
        }
    }

    private IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(1f);

        GetValues();
    }

    private void ResetBools()
    {
        _isCoroutineEnd = false;
        _isMethodCalled = false;
    }
}
