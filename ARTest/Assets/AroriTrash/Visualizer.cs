using Gameplay.Systems.Creators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Visualizer : MonoBehaviour
{
    [SerializeField] private GameObject planeMarkerPrefab;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private Button spawnArenaButton;
    [SerializeField] private Button battleButton;
    [SerializeField] private HeroCreateSystem imageTracking;
    [SerializeField] private GameObject arena;


    void Start()
    {
        arena.SetActive(false);
        planeMarkerPrefab.SetActive(false);
        battleButton.gameObject.SetActive(false);
        battleButton.onClick.AddListener(StartBattle);
        spawnArenaButton.onClick.AddListener(SpawnObject);
    }

    void Update()
    {
        if (imageTracking.tracked)
        {
            ShowMarker();
        }
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }
    }

    void SpawnObject()
    {
        if (!imageTracking.tracked)
            return;

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            arena.transform.position = hits[0].pose.position;
            arena.SetActive(true);
        }

        planeMarkerPrefab.SetActive(false);
        spawnArenaButton.gameObject.SetActive(false);
        imageTracking.text.gameObject.SetActive(false);
        imageTracking.tracked = false;
        battleButton.gameObject.SetActive(true);
    }

    private void StartBattle()
    {
        imageTracking.firstCharacterController.SetTrigger("Attack");
        imageTracking.secondCharacterController.SetTrigger("Attack");
    }
}
