using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    public event Action<string> OnTriggerSkillEffect;

    public void Trigger(string skillName)
    {
        OnTriggerSkillEffect?.Invoke(skillName);
    }
}
