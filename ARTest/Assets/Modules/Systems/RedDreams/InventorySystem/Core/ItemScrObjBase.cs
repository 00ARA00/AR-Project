using UnityEngine;

namespace InventorySystem
{
    public abstract class ItemScrObjBase : ScriptableObject
    {
        public abstract Item Item { get; }
    }
}