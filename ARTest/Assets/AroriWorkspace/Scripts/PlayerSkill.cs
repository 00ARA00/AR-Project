using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    protected PlayerInitializer playerInitializer;

    public virtual void Initialize(PlayerInitializer playerInitializer)
    {
        this.playerInitializer = playerInitializer;
    }
}
