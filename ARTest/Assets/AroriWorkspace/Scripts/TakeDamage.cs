using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;

    private UISystem _uISystem;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _uISystem = spawnInitializer.UISystem;

        _uISystem.OnDamageTakenButtonClick -= OnDamageTakenButtonClick;
        _uISystem.OnDamageTakenButtonClick += OnDamageTakenButtonClick;

        spawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        spawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnDamageTakenButtonClick()
    {
        _playerHealth.TakeDamage(10);
    }

    private void OnImageTracked()
    {
        _playerHealth = spawnInitializer.ImageTracker.HeroInitializer.Health;
    }
}
