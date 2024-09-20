using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerInitializer playerInitializer;
    [SerializeField] private Animator animator;
    [SerializeField] private string idleAnimationName;

    private EnemyActions _enemyActions;
    private UISystem _uISystem;
    public event Action OnEnemyReadyToUseSkill;

    private void Awake()
    {
        if (playerInitializer.EnemyActions != null)
        {
            _enemyActions = playerInitializer.EnemyActions;
        }

        playerInitializer.OnInitializesConnection -= OnInitializesConnection;
        playerInitializer.OnInitializesConnection += OnInitializesConnection;
    }
    private void OnInitializesConnection()
    {
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnImageTracked()
    {
        _uISystem = playerInitializer.SpawnInitializer.UISystem;
    }

    public void SkillAnimation(PlayerSkill playerSkill)
    {
        StartCoroutine(WaitForAnimationEnd(playerSkill.AnimationName, playerSkill.AnimationDelay,playerSkill.IsEnemySkill));
    }

    private IEnumerator WaitForAnimationEnd(string animationName, float delayInSeconds, bool enemySkill)
    {
        Debug.Log(animationName);
        PlayAnimation(animationName);

        yield return new WaitForSeconds(delayInSeconds);

        if (enemySkill) { OnEnemyReadyToUseSkill?.Invoke(); }
        if (!enemySkill) { _uISystem.EnableSkillButtons(); }
    }

    private void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public float GetAnimationLength(string animationName, float delayModificator)
    {
        if (delayModificator <= 0)
            delayModificator = 1;

        RuntimeAnimatorController rac = animator.runtimeAnimatorController;

        foreach (AnimationClip clip in rac.animationClips)
        {
            if (clip.name == animationName)
            {
                return clip.length * delayModificator;
            }
        }

        return 0f;
    }
}
