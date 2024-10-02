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

    private void Awake()
    {
        spawnInitializer.UISystem.OnRespawnButtonClick -= OnRespawnButtonClick;
        spawnInitializer.UISystem.OnRespawnButtonClick += OnRespawnButtonClick;

        spawnInitializer.UISystem.OnDiceRollButtonClick -= OnDiceRollButtonClick;
        spawnInitializer.UISystem.OnDiceRollButtonClick += OnDiceRollButtonClick;
    }

    private void OnRespawnButtonClick()
    {
        ResetBools();
    }

    private void Update()
    {
        if (_isCoroutineEnd)
        {
            DicesCondition();
        }
    }

    private void OnDiceRollButtonClick()
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
            GetValues();
        }
        else
        {
            return;
        }
    }

    private void GetValues()
    {
        if (!_isMethodCalled)
        {
            Debug.Log(strDice.IsDiceStationary + " " + dexDice.IsDiceStationary + " " + intDice.IsDiceStationary);
            Debug.Log(strDice.Side + " " + dexDice.Side + " " + intDice.Side);
            _isMethodCalled = true;
        }
        else
        {
            return;
        }
    }

    private void ResetBools()
    {
        _isCoroutineEnd = false;
        _isMethodCalled = false;
    }
}
