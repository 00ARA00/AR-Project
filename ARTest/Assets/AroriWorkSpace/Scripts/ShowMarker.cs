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
    private PlayerInputSystem _playerInputSystem;
    private ImageTracker _imageTracker;
    private RaycastSystem _raycastSystem;
    private Text _textInstructions;

    private Vector3 _raycastHit;
    private bool _imageTracked;
    private bool _arenaIsCreated;

    private void Awake()
    {
        _planeMarkerPrefab = spawnInitializer.SpawnResources.PlaneMarkerPrefab;
        _playerInputSystem = spawnInitializer.PlayerInputSystem;
        _imageTracker = spawnInitializer.ImageTracker;
        _raycastSystem = spawnInitializer.RaycastSystem;
        _textInstructions = spawnInitializer.SpawnResources.TextInstructions;

        _playerInputSystem.OnSpawnArenaButtonClick -= OnSpawnArenaButtonClick;
        _playerInputSystem.OnSpawnArenaButtonClick += OnSpawnArenaButtonClick;
        _imageTracker.OnImageTracked -= OnImageTracked;
        _imageTracker.OnImageTracked += OnImageTracked;
    }

    private void Start()
    {
        _planeMarkerPrefab.gameObject.SetActive(false);
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
        _textInstructions.gameObject.SetActive(false);
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
