using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackingSetup : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private XRReferenceImageLibrary imageLibrary;

    void Start()
    {
        if (trackedImageManager == null)
        {
            Debug.LogError("ARTrackedImageManager is not assigned.");
            return;
        }

        if (imageLibrary == null)
        {
            Debug.LogError("Reference Image Library is not assigned.");
            return;
        }

        trackedImageManager.referenceLibrary = imageLibrary;
        Debug.Log("Image Library assigned successfully.");
    }
}
