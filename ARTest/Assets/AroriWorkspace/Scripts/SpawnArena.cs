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
    private RaycastSystem _raycastSystem;

    private Vector3 _raycastHit;

    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;
        _arena = spawnInitializer.SpawnResources.Arena;
        _raycastSystem = spawnInitializer.RaycastSystem;

        _uISystem.OnSpawnArenaButtonClick -= OnSpawnArenaButtonClick;
        _uISystem.OnSpawnArenaButtonClick += OnSpawnArenaButtonClick;
    }

    private void OnSpawnArenaButtonClick()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableBattleStarterLayout();
        SpawnArenaOnMarker();
    }

    void SpawnArenaOnMarker()
    {
        _raycastHit = _raycastSystem.GetRaycastHit();
        if (_raycastHit == null)
            return;

        _arena.transform.position = _raycastHit;
        _arena.SetActive(true);
    }

}
