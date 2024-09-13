using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private UISystem _uISystem;
    private GameObject _arena;
    private GameObject _planeMarker;

    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;
        _arena = spawnInitializer.SpawnResources.Arena;
        _planeMarker = spawnInitializer.SpawnResources.PlaneMarker;

        _uISystem.OnPlayGameButtonClick -= OnPlayGameButtonClick;
        _uISystem.OnPlayGameButtonClick += OnPlayGameButtonClick;
    }

    private void Start()
    {
        _arena.SetActive(false);
        _planeMarker.SetActive(false);

        _uISystem.DisableAllUI();
        _uISystem.EnablePlayLayout();
    }

    private void OnPlayGameButtonClick()
    {
        _uISystem.DisableAllUI();
        _uISystem.EnableImageTrackerLayout();
    }
}
