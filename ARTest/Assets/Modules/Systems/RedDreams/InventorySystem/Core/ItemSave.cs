using System;
using UnityEngine;

namespace InventorySystem.Core
{
    [System.Serializable]
    public class ItemSave
    {
        public int ID => _id;
        [SerializeField] private int _id;

        public int Count;
        public ItemSave(int id, int count)
        {
            _id = id;
            Count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj is ItemSave itemSave)
            {
                return ID == itemSave.ID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Count);
        }
    }
}