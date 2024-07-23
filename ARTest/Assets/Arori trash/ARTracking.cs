using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTracking : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager trackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    private void Awake()
    {
        // Добавьте сюда свои AR-объекты
        arObjects.Add("Image1", GameObject.Find("ARObject1"));
        arObjects.Add("Image2", GameObject.Find("ARObject2"));

        // Деактивируем все объекты на старте
        foreach (var arObject in arObjects.Values)
        {
            arObject.SetActive(false);
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
            UpdateARImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateARImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.referenceImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;
        if (arObjects.ContainsKey(imageName))
        {
            GameObject arObject = arObjects[imageName];
            arObject.transform.position = trackedImage.transform.position;
            arObject.transform.rotation = trackedImage.transform.rotation;
            arObject.SetActive(true);
        }
    }
}