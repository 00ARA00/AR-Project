using Game.ScrObj;
using PoolsContainer;
using PoolsContainer.Example;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Gameplay.Systems.Craetors
{
    public class HeroCreateSystem : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private HeroesPrefabsPackScrObj heroesPrefabsPackScrObj;
        [Space]
        [SerializeField] private HeroesPool heroesPool;
        [SerializeField] private HeroesContainer heroesContainer;
        [SerializeField] private ARTrackedImageManager trackedImagesManager;

        private string _name;

        private void Awake()
        {
            //trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        private void OnDestroy()
        {
            //trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.added)
            {
             
                _name = trackedImage.referenceImage.ToString();
            }
            /*
            foreach (var trackedImage in eventArgs.updated)
            {
                trackedImage.
                var imageName = trackedImage.referenceImage.name;
                foreach (var curPrefab in ArPrefabs)
                {
                    if (imageName == curPrefab.name)
                    {
                        var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                        _instantiatedPrefabs[imageName] = newPrefab;
                    }
                }
                
            }

            foreach (var trackedImage in eventArgs.updated)
            {
                _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
            }

            foreach (var trackedImage in eventArgs.removed)
            {
                Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
                _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
            }
            */
        }

        private void CreateHero()
        {

        }

        private void DeleteHero()
        {

        }

      
    }

}
