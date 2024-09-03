using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnInitializer : MonoBehaviour
{
    [SerializeField] private PlayerInputSystem playerInputSystem;
    [SerializeField] private ImageTracker imageTracker;
    [SerializeField] private ARRaycastManager aRRaycastManager;
    [SerializeField] private RaycastSystem raycastSystem;
    [SerializeField] private SpawnResources spawnResources;
    [SerializeField] private ARTrackedImageManager aRTrackedImagesManager;

    public ARTrackedImageManager ARTrackedImageManager => aRTrackedImagesManager;
    public ImageTracker ImageTracker => imageTracker;
    public PlayerInputSystem PlayerInputSystem => playerInputSystem;
    public SpawnResources SpawnResources => spawnResources;
    public ARRaycastManager RaycastManager => aRRaycastManager;
    public RaycastSystem RaycastSystem => raycastSystem;
}
