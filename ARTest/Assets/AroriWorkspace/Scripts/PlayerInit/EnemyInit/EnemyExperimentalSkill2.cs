using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExperimentalSkill2 : PlayerSkill
{
    [SerializeField] private float damage;

    protected override void SkillEffect()
    {
        enemyInitializer.Health.TakeDamage(damage);
    }
}
