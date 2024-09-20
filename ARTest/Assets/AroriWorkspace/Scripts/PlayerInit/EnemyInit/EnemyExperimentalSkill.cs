using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExperimentalSkill : PlayerSkill
{
    [SerializeField] private float skillDamage;

    protected override void SkillEffect()
    {
        enemyInitializer.Health.TakeDamage(skillDamage);
    }
}
