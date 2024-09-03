using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastSystem : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private ARRaycastManager _ARRaycastManager;
    private Vector3 _raycastHit = new Vector3();

    private void Awake()
    {
        _ARRaycastManager = spawnInitializer.RaycastManager;
    }

    public Vector3 GetRaycastHit()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        _ARRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            _raycastHit = hits[0].pose.position;
            return _raycastHit;
        }
        return _raycastHit;
    }
}
