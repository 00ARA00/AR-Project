using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    [SerializeField] private Rigidbody[] dicesRigidbodies;

    [SerializeField] private float rollForceMin;
    [SerializeField] private float rollForceMax;

    [SerializeField] private float rotationForceMin;
    [SerializeField] private float rotationForceMax;

    private Vector3 forceVector;
    private System.Random _random;


    private void Awake()
    {
        spawnInitializer.UISystem.OnRollStatsButtonClick -= OnRollStatsButtonClick;
        spawnInitializer.UISystem.OnRollStatsButtonClick += OnRollStatsButtonClick;

        _random = spawnInitializer.SpawnResources.Random;
        forceVector = new Vector3(-1, 0, 0);
    }

    private void OnRollStatsButtonClick()
    {
        Roll();
    }

    private void Roll()
    {
        foreach (var d in dicesRigidbodies)
        {
            d.isKinematic = false;
            d.useGravity = true;
            d.AddForce(forceVector.normalized * RandomizeForce(), ForceMode.Impulse);
            d.AddTorque(RandomizeVector().normalized * RandomizeRotationForce(), ForceMode.Impulse);
        }
    }

    private Vector3 RandomizeVector()
    {
        Vector3 rotationVector;

        do
        {
            rotationVector = new Vector3(_random.Next(-1, 2), _random.Next(-1, 2), _random.Next(-1, 2));
        } while (rotationVector == Vector3.zero);

        return rotationVector;
    }

    private float RandomizeForce()
    {
        float force = rollForceMin + (float)_random.NextDouble() * (rollForceMax - rollForceMin);
        return force;
    }

    private float RandomizeRotationForce()
    {
        float force = rotationForceMin + (float)_random.NextDouble() * (rotationForceMax - rotationForceMin);
        return force;
    }
}
