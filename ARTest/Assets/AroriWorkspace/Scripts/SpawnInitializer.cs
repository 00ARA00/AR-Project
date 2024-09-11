using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnInitializer : MonoBehaviour
{
    [SerializeField] private UISystem uISystem;
    [SerializeField] private ImageTracker imageTracker;
    [SerializeField] private ARRaycastManager aRRaycastManager;
    [SerializeField] private RaycastSystem raycastSystem;
    [SerializeField] private SpawnResources spawnResources;
    [SerializeField] private ARTrackedImageManager aRTrackedImagesManager;


    private PlayerInitializer _playerInitializer;


    public PlayerInitializer PlayerInitializer => _playerInitializer;
    public ARTrackedImageManager ARTrackedImageManager => aRTrackedImagesManager;
    public ImageTracker ImageTracker => imageTracker;
    public UISystem UISystem => uISystem;
    public SpawnResources SpawnResources => spawnResources;
    public ARRaycastManager RaycastManager => aRRaycastManager;
    public RaycastSystem RaycastSystem => raycastSystem;
}
