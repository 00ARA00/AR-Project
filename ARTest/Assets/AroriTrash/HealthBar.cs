using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public Slider healthBarSlider;
    [SerializeField] public Slider easeHealthBarSlider;
    [SerializeField] private float maxHealth = 100;
    public float damage = 10;
    public float currentHealth;
    private float lerpSpeed = 0.05f;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (healthBarSlider.value != easeHealthBarSlider.value)
        {
            easeHealthBarSlider.value = Mathf.Lerp(easeHealthBarSlider.value, currentHealth, lerpSpeed);
        }

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    private void Death()
    {
        animator.ResetTrigger("Attack");
        animator.SetTrigger("Death");
    }

    public void TakeDamage()
    {
        currentHealth -= damage;
        healthBarSlider.value = currentHealth;
    }
}
