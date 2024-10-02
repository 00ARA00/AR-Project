using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [SerializeField] private Button spawnArenaButton;
    [SerializeField] private Button startBattleButton;
    [SerializeField] private Button playGameButton;
    [SerializeField] private Button rollStatsButton;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Button autoScanButton;
    [SerializeField] private GameObject textWin;
    [SerializeField] private GameObject textLose;
    [SerializeField] private GameObject gameName;
    [SerializeField] private GameObject instructions;
    [SerializeField] private TextMeshProUGUI textInstructions;
    [SerializeField] private SkillsPanel skillsPanel;
    [SerializeField] private StatsWidget statsWidget;
    [SerializeField] private Button rollDicesButton;
    [SerializeField] private Button respawnButton;

    public SkillsPanel SkillsPanel => skillsPanel;

    public event Action OnRespawnButtonClick;
    public event Action OnDiceRollButtonClick;
    public event Action OnAutoScanBattonClick;
    public event Action OnPlayGameButtonClick;
    public event Action OnSpawnArenaButtonClick;
    public event Action OnStartBattleButtonClick;
    public event Action OnRollStatsButtonClick;
    public event Action OnEndTurnButtonClick;

    private void Awake()
    {
        respawnButton.onClick?.AddListener(() => OnRespawnButtonClick?.Invoke());
        rollDicesButton.onClick?.AddListener(() => OnDiceRollButtonClick?.Invoke());
        autoScanButton.onClick?.AddListener(() => OnAutoScanBattonClick?.Invoke());
        endTurnButton.onClick?.AddListener(() => OnEndTurnButtonClick?.Invoke());
        playGameButton.onClick?.AddListener(() => OnPlayGameButtonClick?.Invoke());
        spawnArenaButton.onClick?.AddListener(() => OnSpawnArenaButtonClick?.Invoke());
        startBattleButton.onClick?.AddListener(() => OnStartBattleButtonClick?.Invoke());
        rollStatsButton.onClick?.AddListener(() => OnRollStatsButtonClick?.Invoke());
    }

    public void DisableAllUI()
    {
        autoScanButton.gameObject.SetActive(false);
        textWin.SetActive(false);
        textLose.SetActive(false);
        statsWidget.gameObject.SetActive(false);
        rollStatsButton.gameObject.SetActive(false);
        spawnArenaButton.gameObject.SetActive(false);
        startBattleButton.gameObject.SetActive(false);
        playGameButton.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
        instructions.SetActive(false);
        gameName.SetActive(false);
        skillsPanel.gameObject.SetActive(false);
    }

    public void EnablePlayLayout()
    {
        gameName.SetActive(true);
        playGameButton.gameObject.SetActive(true);
    }

    public void EnableImageTrackerLayout()
    {
        instructions.SetActive(true);
        autoScanButton.gameObject.SetActive(true);
    }

    public void EnableArenaCreatorLayout()
    {
        instructions.SetActive(true);
        spawnArenaButton.gameObject.SetActive(true);
        ChangeInstructionsText("Choose place to create Arena");
    }

    public void EnableBattleStarterLayout()
    {
        instructions.SetActive(true);
        startBattleButton.gameObject.SetActive(true);
        ChangeInstructionsText("Ready to start battle?");
    }
    public void EnableStatsRollLayout()
    {
        instructions.SetActive(true);
        statsWidget.gameObject.SetActive(true);
        skillsPanel.gameObject.SetActive(true);
        rollStatsButton.gameObject.SetActive(true);
        ChangeInstructionsText("Your turn");
    }

    public void EnableBattleLayout()
    {
        instructions.SetActive(true);
        statsWidget.gameObject.SetActive(true);
        skillsPanel.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(true);
        ChangeInstructionsText("Your turn");
    }

    public void EnableEnemyTurnLyout()
    {
        instructions.SetActive(true);
        skillsPanel.gameObject.SetActive(true);
        ChangeInstructionsText("Enemy's turn");
    }

    public void EnableLoseLayout()
    {
        textLose.SetActive(true);
    }

    public void EnableWinLayout()
    {
        textWin.SetActive(true);
    }

    public void ChangeInstructionsText(string text)
    {
        instructions.SetActive(true);
        textInstructions.text = text;
    }

    public void DisableAllSkillButtons()
    {
        for (int i = 0;i < skillsPanel.SkillButtons.Length; i++)
        {
            skillsPanel.SkillButtons[i].DisableSkillButton();
        }
    }

    public void EnableAllSkillButtons()
    {
        for (int i = 0; i < skillsPanel.SkillButtons.Length; i++)
        {
            skillsPanel.SkillButtons[i].EnableSkillButton();
        }
    }
}
