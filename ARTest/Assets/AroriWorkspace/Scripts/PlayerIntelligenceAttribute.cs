using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntelligenceAttribute : MonoBehaviour
{
    [SerializeField] private PlayerInitializer playerInitializer;

    public float Intelligence { get; private set; }

    private void Awake()
    {
        Intelligence = playerInitializer.Stats.IntelligentAttribute;
    }
}
