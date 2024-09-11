using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShowMarker : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private GameObject _planeMarkerPrefab;
    private UISystem _uISystem;
    private ImageTracker _imageTracker;
    private RaycastSystem _raycastSystem;

    private Vector3 _raycastHit;
    private bool _imageTracked;
    private bool _arenaIsCreated;

    private void Awake()
    {
        _planeMarkerPrefab = spawnInitializer.SpawnResources.PlaneMarker;
        _uISystem = spawnInitializer.UISystem;
        _imageTracker = spawnInitializer.ImageTracker;
        _raycastSystem = spawnInitializer.RaycastSystem;

        _uISystem.OnSpawnArenaButtonClick -= OnSpawnArenaButtonClick;
        _uISystem.OnSpawnArenaButtonClick += OnSpawnArenaButtonClick;

        _imageTracker.OnImageTracked -= OnImageTracked;
        _imageTracker.OnImageTracked += OnImageTracked;
    }

    private void Update()
    {
        if (!_imageTracked || _arenaIsCreated)
            return;
        ShowMarkerOnGround();
    }

    private void OnSpawnArenaButtonClick()
    {
        _arenaIsCreated = true;
        _planeMarkerPrefab.SetActive(false);
    }

    private void OnImageTracked()
    {
        _imageTracked = true;

        _uISystem.DisableAllUI();
        _uISystem.ChangeInstructionsText("Choose place to create Arena.");
        _uISystem.EnableArenaCreatorLayout();
    }

    private void ShowMarkerOnGround()
    {
        _raycastHit = _raycastSystem.GetRaycastHit();
        if (_raycastHit == null)
            return;

        _planeMarkerPrefab.transform.position = _raycastHit;
        _planeMarkerPrefab.SetActive(true);
    }
}
