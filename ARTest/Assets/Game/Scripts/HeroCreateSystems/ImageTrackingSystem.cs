using Game.ScrObj;
using PoolsContainer;
using PoolsContainer.Example;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace Gameplay.Systems.Creators
{
    public class ImageTrackingSystem : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private ARTrackedImageManager trackedImagesManager;

        [SerializeField] public Text text;

        [SerializeField] private List<GameObject> arObjectPrefabs;

        [SerializeField] private Transform firstCharacterTransform;

        [SerializeField] private Transform secondCharacterTransform;

        [SerializeField] private Transform camera;

        [NonSerialized] public HealthBar firstCharacterHealthBar;

        [NonSerialized] public HealthBar secondCharacterHealthBar;

        [NonSerialized] public GameObject firstCharacter;

        [NonSerialized] public GameObject secondCharacter;

        [NonSerialized] public Animator firstCharacterController;
        [NonSerialized] public Animator secondCharacterController;

        private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

        public bool tracked = false;

        private string firstImageName;

        private string secondImageName;


        private void Awake()
        {
            trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
            trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;

            text.text = "Please track first image.";
            foreach (var prefab in arObjectPrefabs)
            {
                arObjects.Add(prefab.name, prefab);
            }

        }

        private void OnDestroy()
        {
            trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.added)
            {
                if (firstImageName == null)
                {
                    firstImageName = trackedImage.referenceImage.name;
                    firstCharacter = Instantiate(arObjects[firstImageName], firstCharacterTransform.position, firstCharacterTransform.rotation);
                    firstCharacter.transform.parent = firstCharacterTransform;
                    firstCharacter.GetComponent<Attack>().createSystem = GetComponent<ImageTrackingSystem>();
                    firstCharacterController = firstCharacter.GetComponent<Animator>();
                    firstCharacter.GetComponent<Billboard>().camera = this.camera;
                    firstCharacterHealthBar = firstCharacter.GetComponent<HealthBar>();
                    

                    text.text = "Please track second image.";
                }
                if (firstImageName != null && trackedImage.referenceImage.name != firstImageName)
                {
                    secondImageName = trackedImage.referenceImage.name;
                    secondCharacter = Instantiate(arObjects[secondImageName], secondCharacterTransform.position, secondCharacterTransform.rotation);
                    secondCharacter.transform.parent = secondCharacterTransform;
                    secondCharacter.GetComponent<Attack>().createSystem = GetComponent<ImageTrackingSystem>();
                    secondCharacterController = secondCharacter.GetComponent<Animator>();
                    secondCharacter.GetComponent<Billboard>().camera = this.camera;
                    secondCharacterHealthBar = secondCharacter.GetComponent<HealthBar>();
                    text.text = "Images tracked.";
                    tracked = true;
                }
            }
        }
    }

}
