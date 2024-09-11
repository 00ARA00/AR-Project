using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    public event Action OnTriggerSkillEffect;

    public void Trigger()
    {
        OnTriggerSkillEffect?.Invoke();
    }
}
