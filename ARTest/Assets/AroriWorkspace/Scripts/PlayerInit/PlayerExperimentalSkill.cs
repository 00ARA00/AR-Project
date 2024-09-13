using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperimentalSkill : PlayerSkill
{
    [SerializeField] private float skillDamage;

    protected override void SkillEffect()
    {
        enemyInitializer.Health.TakeDamage(skillDamage);
    }
}
