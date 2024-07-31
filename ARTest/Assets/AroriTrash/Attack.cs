using Gameplay.Systems.Creators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AttackAnimationEvent animationEvent;
    [NonSerialized] public HeroCreateSystem createSystem;

    private HealthBar enemyHealthBar;

    private void Start()
    {
        if (transform.gameObject.name == createSystem.firstCharacter.name)
        {
            enemyHealthBar = createSystem.secondCharacterHealthBar;
        }
        else
        {
            enemyHealthBar = createSystem.firstCharacterHealthBar;
        }

        animationEvent.attackAnimationEvent.AddListener(OnAnimationEvent);
    }

    private void Update()
    {
        if (enemyHealthBar.currentHealth <= 0)
        {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Victory");
        }
    }

    private void OnAnimationEvent(string eventName)
    {
        switch (eventName)
        {
            case "attack_impact":
                AttackImpact();
                break;
        }
    }

    private void AttackImpact()
    {
        enemyHealthBar.TakeDamage();
    }
}