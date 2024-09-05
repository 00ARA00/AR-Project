using Gameplay.Systems.Creators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnArena : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private UISystem _uISystem;
    private GameObject _arena;
    private Button _spawnArenaButton;
    private Button _startBattleButton;
    private RaycastSystem _raycastSystem;

    private Vector3 _raycastHit;

    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;
        _arena = spawnInitializer.SpawnResources.Arena;
        _spawnArenaButton = spawnInitializer.UISystem.SpawnArenaButton;
        _startBattleButton = spawnInitializer.UISystem.StartBattleButton;
        _raycastSystem = spawnInitializer.RaycastSystem;

        _uISystem.OnSpawnArenaButtonClick -= OnSpawnArenaButtonClick;
        _uISystem.OnSpawnArenaButtonClick += OnSpawnArenaButtonClick;
    }

    private void Start()
    {
        _startBattleButton.gameObject.SetActive(false);
    }

    private void OnSpawnArenaButtonClick()
    {
        SpawnArenaOnMarker();
    }

    void SpawnArenaOnMarker()
    {
        _raycastHit = _raycastSystem.GetRaycastHit();
        if (_raycastHit == null)
            return;

        _arena.transform.position = _raycastHit;
        _arena.SetActive(true);

        _spawnArenaButton.gameObject.SetActive(false);
        _startBattleButton.gameObject.SetActive(true);
    }

}
