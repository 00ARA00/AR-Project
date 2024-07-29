using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARImageTracking : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;

    [SerializeField] private List<GameObject> arObjectPrefabs;

    [SerializeField] private Text text;

    [SerializeField] private Visualizer visualizer;

    [SerializeField] private Transform firstCharacterTransform;

    [SerializeField] private Transform secondCharacterTransform;


    [NonSerialized] public GameObject firstCharacter;
    [NonSerialized] public GameObject secondCharacter;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    public bool tracked = false;

    private string firstImageName;

    private string secondImageName;

    private void Awake()
    {
        text.text = "Please track first image.";
        Debug.Log("asd");
        foreach (var prefab in arObjectPrefabs)
        {
            arObjects.Add(prefab.name, prefab);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            text.text = trackedImage.referenceImage.name;
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            text.text = trackedImage.referenceImage.name;
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            text.text = trackedImage.referenceImage.name;
        }
        //if (firstImageName == null)
        //{
        //    foreach (var trackedImage in eventArgs.added)
        //    {
        //        FirstImage(trackedImage);
        //    }
        //}

        //if (firstImageName != null)
        //{

        //    foreach (var trackedImage in eventArgs.added)
        //    {

        //        if (trackedImage.referenceImage.name != firstImageName)
        //        {
        //            text.text = "asd";
        //            SecondImage(trackedImage);

        //        }
        //    }

        //}
    }

    private void FirstImage(ARTrackedImage trackedImage)
    {
        if (firstImageName == null)
        {
            firstImageName = trackedImage.referenceImage.name;
            firstCharacter = Instantiate(arObjects[firstImageName]);
            firstCharacter.transform.parent = firstCharacterTransform;
            text.text = "Please track second image.";
        }
    }

    private void SecondImage(ARTrackedImage trackedImage)
    {
        if (firstImageName != null && trackedImage.referenceImage.name != firstImageName)
        {
            secondImageName = trackedImage.referenceImage.name;
            secondCharacter = Instantiate(arObjects[secondImageName]);
            secondCharacter.transform.parent = secondCharacterTransform;
            text.text = "Images tracked.";
        }
    }
}
