using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDexterityAttribute : MonoBehaviour
{
    [SerializeField] private PlayerInitializer playerInitializer;

    public float Dexterity { get; private set; }

    private void Awake()
    {
        Dexterity = playerInitializer.Stats.Dexterity;
    }
}
