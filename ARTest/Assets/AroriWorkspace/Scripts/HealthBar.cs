using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerInitializer playerInitializer;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private Slider easeHealthBarSlider;

    private float lerpSpeed = 0.1f;

    private PlayerHealth _playerHealth;
    private bool _isLerping;

    private void Awake()
    {

        playerInitializer.Health.OnDamageTaken -= OnDamageTaken;
        playerInitializer.Health.OnDamageTaken += OnDamageTaken;

        _playerHealth = playerInitializer.Health;

    }

    private void Start()
    {
        healthBarSlider.maxValue = _playerHealth.MaxHealth;
        healthBarSlider.value = _playerHealth.Health;

        easeHealthBarSlider.maxValue = healthBarSlider.maxValue;
        easeHealthBarSlider.value = healthBarSlider.value;
        
    }

    private void Update()
    {
        if (_isLerping)
            LerpHealth(_playerHealth.Health);
    }

    private void OnDamageTaken()
    {
        _isLerping = true;
    }

    private void LerpHealth(float currentHealth)
    {
        healthBarSlider.value = currentHealth;

        if (healthBarSlider.value != easeHealthBarSlider.value)
        {
            easeHealthBarSlider.value = Mathf.Lerp(easeHealthBarSlider.value, healthBarSlider.value, lerpSpeed);
        }
        else
        {
            _isLerping = false;
        }
    }
}
