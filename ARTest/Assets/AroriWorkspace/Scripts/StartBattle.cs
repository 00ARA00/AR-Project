using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private UISystem _uISystem;
    private Button _startBattleButton;

    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;

        _uISystem.OnStartBattleButtonClick -= OnStartBattleButtonClick;
        _uISystem.OnStartBattleButtonClick += OnStartBattleButtonClick;
    }

    private void OnStartBattleButtonClick()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableBattleLayout();
    }
}
