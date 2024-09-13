using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrengthAttribute : MonoBehaviour
{
    [SerializeField] private PlayerInitializer playerInitializer;

    public float Strength { get; private set; }

    private void Awake()
    {
        Strength = playerInitializer.Stats.StrengthAttribute;
    }
}
