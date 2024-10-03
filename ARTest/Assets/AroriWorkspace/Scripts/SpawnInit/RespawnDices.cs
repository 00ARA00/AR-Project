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

    private UISystem _uiSystem;

    private void Awake()
    {
        _uiSystem = spawnInitializer.UISystem;

        _uiSystem.OnEndTurnButtonClick -= OnEndTurnButtonClick;
        _uiSystem.OnEndTurnButtonClick += OnEndTurnButtonClick;


        for (int i = 0; i < dicesTransform.Count(); i++)
        {
            dicesPositions[i] = dicesTransform[i].position;
            dicesRotations[i] = dicesTransform[i].rotation;
        }
    }

    private void OnEndTurnButtonClick()
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
