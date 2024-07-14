using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/Items/ItemData", order = 0)]
    public class ItemScrObj : ItemScrObjBase
    {
        public override Item Item => item;
        [SerializeField] private Item item;
    }
}