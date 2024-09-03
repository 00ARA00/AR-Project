using Gameplay.Systems.Creators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    public event Action OnImageTracked;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    private ARTrackedImageManager _aRTrackedImagesManager;

    private Transform _firstCharacterTransform;
    private Transform _secondCharacterTransform;

    private GameObject _firstCharacter;
    private GameObject _secondCharacter;

    private List<GameObject> _aRObjectPrefabs;

    private Text _textInstructions;

    public GameObject FirstCharacter => _firstCharacter;
    public GameObject SecondCharacter => _secondCharacter;

    private string _firstImageName;
    private string _secondImageName;

    private void Awake()
    {
        _aRTrackedImagesManager = spawnInitializer.ARTrackedImageManager;
        _firstCharacterTransform = spawnInitializer.SpawnResources.FirstCharacter.transform;
        _secondCharacterTransform = spawnInitializer.SpawnResources.SecondCharacter.transform;
        _aRObjectPrefabs = spawnInitializer.SpawnResources.ARObjectPrefabs;
        _textInstructions = spawnInitializer.SpawnResources.TextInstructions;

        _aRTrackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
        _aRTrackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;

        foreach (var prefab in _aRObjectPrefabs)
        {
            arObjects.Add(prefab.name, prefab);
        }
    }

    private void Start()
    {
        _textInstructions.text = "Please track first image.";
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            if (_firstImageName == null)
            {
                _firstImageName = trackedImage.referenceImage.name;
                SpawnPlayer(_firstCharacter, _firstImageName, _firstCharacterTransform);
                _textInstructions.text = "Please track second image.";
            }

            if (_firstImageName != null && trackedImage.referenceImage.name != _firstImageName)
            {
                _secondImageName = trackedImage.referenceImage.name;
                SpawnPlayer(_secondCharacter, _secondImageName, _secondCharacterTransform);

                OnImageTracked?.Invoke();
                _textInstructions.text = "Images are tracked.";
            }
        }
    }

    private void SpawnPlayer(GameObject character, string imageName, Transform spawnPoint)
    {
        character = Instantiate(arObjects[imageName], spawnPoint.position, spawnPoint.rotation);
        character.transform.parent = spawnPoint;
    }

}
