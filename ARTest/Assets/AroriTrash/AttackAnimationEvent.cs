using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AnimationEvent : UnityEvent<string>
{

}

public class AttackAnimationEvent : MonoBehaviour
{
    public AnimationEvent attackAnimationEvent =  new AnimationEvent();

    public void OnAnimationEvent(string eventName)
    {
        attackAnimationEvent.Invoke(eventName);
    }
}
