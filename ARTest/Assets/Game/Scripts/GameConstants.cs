using Game.ScrObj;
using Gameplay.Heroes;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class GameConstants
{
    private static StringBuilder _builder = new StringBuilder();

    public static bool TryGetPrefabByID<T>(this HeroesPrefabsPack[] packs, string key, out HeroInitializer outPrefab)
    {
        outPrefab = null;
        for (int i = 0; i < packs.Length; i++)
            if (packs[i].heroKey == key)
            {
                outPrefab = packs[i].heroPrefab;
                break;
            }
        return outPrefab != null;
    }
}
