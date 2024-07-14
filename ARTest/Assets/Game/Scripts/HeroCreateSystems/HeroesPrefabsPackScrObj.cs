using Gameplay.Heroes;
using System;
using UnityEngine;

namespace Game.ScrObj
{
    [CreateAssetMenu(fileName = "HeroesPrefabsPack", menuName = "ScriptableObjects/HeroesPrefabsPack", order = 0)]
    public class HeroesPrefabsPackScrObj : ScriptableObject
    {
        public HeroesPrefabsPack[] Packs => packs;
        [SerializeField] private HeroesPrefabsPack[] packs;
    }

    [Serializable]
    public struct HeroesPrefabsPack
    {
        public string heroKey;
        public HeroInitializer heroPrefab;
    }
}

