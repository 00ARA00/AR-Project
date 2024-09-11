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
    [SerializeField] private Button takeDamageButton;
    [SerializeField] private TextMeshProUGUI textInstructions;
    [SerializeField] private TextMeshProUGUI gameName;
    [SerializeField] private SkillsPanel skillsPanel;

    public SkillsPanel SkillsPanel => skillsPanel;

    public event Action OnPlayGameButtonClick;
    public event Action OnSpawnArenaButtonClick;
    public event Action OnStartBattleButtonClick;
    public event Action OnDamageTakenButtonClick;

    private void Awake()
    {
        playGameButton.onClick?.AddListener(() => OnPlayGameButtonClick?.Invoke());
        spawnArenaButton.onClick?.AddListener(() => OnSpawnArenaButtonClick?.Invoke());
        startBattleButton.onClick?.AddListener(() => OnStartBattleButtonClick?.Invoke());
        takeDamageButton.onClick?.AddListener(() => OnDamageTakenButtonClick?.Invoke());
    }

    public void DisableAllUI()
    {
        takeDamageButton.gameObject.SetActive(false);
        spawnArenaButton.gameObject.SetActive(false);
        startBattleButton.gameObject.SetActive(false);
        playGameButton.gameObject.SetActive(false);
        textInstructions.gameObject.SetActive(false);
        gameName.gameObject.SetActive(false);
        skillsPanel.gameObject.SetActive(false);
    }

    public void EnablePlayLayout()
    {
        gameName.gameObject.SetActive(true);
        playGameButton.gameObject.SetActive(true);
    }

    public void EnableImageTrackerLayout()
    {
        textInstructions.gameObject.SetActive(true);
    }

    public void EnableArenaCreatorLayout()
    {
        textInstructions.gameObject.SetActive(true);
        spawnArenaButton.gameObject.SetActive(true);
    }

    public void EnableBattleStarterLayout()
    {
        textInstructions.gameObject.SetActive(true);
        startBattleButton.gameObject.SetActive(true);
    }

    public void EnableBattleLayout()
    {
        takeDamageButton.gameObject.SetActive(true);
        skillsPanel.gameObject.SetActive(true);
    }

    public void ChangeInstructionsText(string text)
    {
        textInstructions.gameObject.SetActive(true);
        textInstructions.text = text;
    }
}
