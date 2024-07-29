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
    [SerializeField] private Button button;
    [SerializeField] private ARImageTracking imageTracking;
    [SerializeField] private GameObject arena;

    void Start()
    {
        arena.SetActive(false);
        planeMarkerPrefab.SetActive(false);
        button.onClick.AddListener(SpawnObject);
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
    }
}
