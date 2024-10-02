using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RespawnDices : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    [SerializeField] private Transform[] dicesTransform;
    [SerializeField] private Rigidbody[] rigidbodies; 

    private Vector3[] dicesPositions = new Vector3[3];
    private Quaternion[] dicesRotations = new Quaternion[3];

    private void Awake()
    {
        spawnInitializer.UISystem.OnRespawnButtonClick -= OnRespawnButtonClick;
        spawnInitializer.UISystem.OnRespawnButtonClick += OnRespawnButtonClick;

        for (int i = 0; i < dicesTransform.Count(); i++)
        {
            dicesPositions[i] = dicesTransform[i].position;
            dicesRotations[i] = dicesTransform[i].rotation;
        }
    }

    private void OnRespawnButtonClick()
    {
        Respawn();
    }

    private void Respawn()
    {
        for (int i = 0; i < dicesTransform.Count(); i++)
        {
            rigidbodies[i].isKinematic = true;
            rigidbodies[i].useGravity = false;
            dicesTransform[i].position = dicesPositions[i];
            dicesTransform[i].rotation = dicesRotations[i];
        }
    }
}
