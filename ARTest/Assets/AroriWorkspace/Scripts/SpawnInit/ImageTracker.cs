using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using static UnityEngine.EventSystems.EventTrigger;

public class ImageTracker : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    public event Action OnImageTracked;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    private ARTrackedImageManager _aRTrackedImagesManager;

    private Transform _firstCharacterTransform;
    private Transform _secondCharacterTransform;

    private List<GameObject> _heroList = new List<GameObject>();
    private List<GameObject> _enemyList = new List<GameObject>();

    private List<string> _heroNamesList = new List<string>();
    private List<string> _enemyNamesList = new List<string>();

    private UISystem _uISystem;

    private PlayerInitializer _heroInitializer;
    private PlayerInitializer _enemyInitializer;

    public PlayerInitializer HeroInitializer => _heroInitializer;
    public PlayerInitializer EnemyInitializer => _enemyInitializer;

    private bool _heroIsScaned;

    private string _heroImageName = "Hu_M_Crusader_Pe";
    private string _enemyImageName = "Lich_Blood";


    private void Awake()
    {
        _aRTrackedImagesManager = spawnInitializer.ARTrackedImageManager;
        _firstCharacterTransform = spawnInitializer.SpawnResources.FirstCharacter.transform;
        _secondCharacterTransform = spawnInitializer.SpawnResources.SecondCharacter.transform;
        _heroList = spawnInitializer.SpawnResources.HeroList;
        _enemyList = spawnInitializer.SpawnResources.EnemyList;
        _uISystem = spawnInitializer.UISystem;


        _uISystem.OnPlayGameButtonClick -= OnPlayGameButtonClick;
        _uISystem.OnPlayGameButtonClick += OnPlayGameButtonClick;

        foreach (var prefab in _heroList)
        {
            _heroNamesList.Add(prefab.name);
            arObjects.Add(prefab.name, prefab);
        }

        foreach (var prefab in _enemyList)
        {
            _enemyNamesList.Add(prefab.name);
            arObjects.Add(prefab.name, prefab);
        }
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.updated)
        {
            if (_heroNamesList.Contains(trackedImage.referenceImage.name) && !_heroIsScaned)
            {
                string _imageName = trackedImage.referenceImage.name;

                _heroInitializer = SpawnCharacter(_imageName, _firstCharacterTransform);

                _uISystem.ChangeInstructionsText("Please track your enemy.");
                _heroIsScaned = true;
            }

            if (_enemyNamesList.Contains(trackedImage.referenceImage.name) && _heroIsScaned)
            {
                string _imageName = trackedImage.referenceImage.name;
                _enemyInitializer = SpawnCharacter(_imageName, _secondCharacterTransform);

                _uISystem.ChangeInstructionsText("Choose place to create Arena.");

                OnImageTracked?.Invoke();
                _aRTrackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
            }
        }
    }

    private void AutoScan()
    {
        _heroInitializer = SpawnCharacter(_heroImageName, _firstCharacterTransform);
        _enemyInitializer = SpawnCharacter(_enemyImageName, _secondCharacterTransform);

        OnImageTracked?.Invoke();
        _aRTrackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnPlayGameButtonClick()
    {
        _aRTrackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
        _aRTrackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;

        _uISystem.ChangeInstructionsText("Please track your Hero.");
        _uISystem.EnableImageTrackerLayout();

        _uISystem.OnAutoScanBattonClick -= OnAutoScanBattonClick;
        _uISystem.OnAutoScanBattonClick += OnAutoScanBattonClick;
    }

    private void OnAutoScanBattonClick()
    {
        AutoScan();
    }

    private PlayerInitializer SpawnCharacter(string imageName, Transform spawnPoint)
    {
        GameObject character = Instantiate(arObjects[imageName], spawnPoint.position, spawnPoint.rotation);
        PlayerInitializer playerInitializer = character.GetComponent<PlayerInitializer>();
        playerInitializer.InitializeSI(spawnInitializer);
        character.transform.parent = spawnPoint;
        return playerInitializer;
    }
}
