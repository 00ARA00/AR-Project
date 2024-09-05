using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [SerializeField] private Button spawnArenaButton;
    [SerializeField] private Button startBattleButton;
    [SerializeField] private Text textInstructions;

    public Text TextInstructions => textInstructions;
    public Button SpawnArenaButton => spawnArenaButton;
    public Button StartBattleButton => startBattleButton;

    public event Action OnSpawnArenaButtonClick;
    public event Action OnStartBattleButtonClick;

    private void Awake()
    {
        spawnArenaButton.onClick?.AddListener(() => OnSpawnArenaButtonClick?.Invoke());

        startBattleButton.onClick?.AddListener(() => OnStartBattleButtonClick?.Invoke());
    }
}
