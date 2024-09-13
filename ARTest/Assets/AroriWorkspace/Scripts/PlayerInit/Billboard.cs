using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private PlayerInitializer playerInitializer;
    [SerializeField] private Transform healthBarTransform;

    private Transform _camera;

    private void Awake()
    {
        playerInitializer.OnInitializesConnection -= OnInitializesConnection;
        playerInitializer.OnInitializesConnection += OnInitializesConnection;
    }

    private void OnInitializesConnection()
    {
        _camera = playerInitializer.SpawnInitializer.SpawnResources.Camera;
    }

    private void LateUpdate()
    {
        if (_camera != null)
            healthBarTransform.LookAt(healthBarTransform.position + _camera.forward);
    }
}
