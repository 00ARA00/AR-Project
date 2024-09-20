using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;
    [SerializeField] private Turn _turn;

    private UISystem _uISystem;
    private TurnBasedSystem _turnBasedSystem;
    private Button _startBattleButton;

    private void Awake()
    {
        _turnBasedSystem = spawnInitializer.TurnBasedSystem;
        _uISystem = spawnInitializer.UISystem;

        _uISystem.OnStartBattleButtonClick -= OnStartBattleButtonClick;
        _uISystem.OnStartBattleButtonClick += OnStartBattleButtonClick;
    }

    private void OnStartBattleButtonClick()
    {
        _turnBasedSystem.ChangeTurn(_turn);
    }
}
