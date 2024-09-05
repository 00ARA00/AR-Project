using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private SkillsPanel _skillsPanel;
    private UISystem _uISystem;
    private Button _startBattleButton;

    private void Awake()
    {
        _skillsPanel = spawnInitializer.SkillsPanel;
        _uISystem = spawnInitializer.UISystem;
        _startBattleButton = spawnInitializer.UISystem.StartBattleButton;

        _uISystem.OnStartBattleButtonClick -= OnStartBattleButtonClick;
        _uISystem.OnStartBattleButtonClick += OnStartBattleButtonClick;
    }

    private void Start()
    {
        _skillsPanel.gameObject.SetActive(false);
    }

    private void OnStartBattleButtonClick()
    {
        _skillsPanel.gameObject.SetActive(true);
        _startBattleButton.gameObject.SetActive(false);
    }
}
