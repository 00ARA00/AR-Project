using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerInitializer playerInitializer;
    [SerializeField] private Animator animator;

    public void SkillAnimation(string skillAnimationName)
    {
        animator.Play(skillAnimationName);
    }
}
