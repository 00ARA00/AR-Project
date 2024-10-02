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
    [SerializeField] private TurnBasedSystem turnBasedSystem;
    [SerializeField] private DiceRoll diceRoll;

    public DiceRoll DiceRoll => diceRoll;
    public TurnBasedSystem TurnBasedSystem => turnBasedSystem;
    public PlayerInitializer HeroInitializer => imageTracker.HeroInitializer;
    public PlayerInitializer EnemyInitializer => imageTracker.EnemyInitializer;
    public ARTrackedImageManager ARTrackedImageManager => aRTrackedImagesManager;
    public ImageTracker ImageTracker => imageTracker;
    public UISystem UISystem => uISystem;
    public SpawnResources SpawnResources => spawnResources;
    public ARRaycastManager RaycastManager => aRRaycastManager;
    public RaycastSystem RaycastSystem => raycastSystem;
}
