using UnityEngine;

namespace InventorySystem
{
    [System.Serializable]
    public class Item 
    {
        public int ID => id;
        [SerializeField] private int id;

        public virtual ItemsCategories Category => category;
        [SerializeField] private ItemsCategories category;

        public virtual ItemRanks Rank => rank;
        [SerializeField] private ItemRanks rank;

        public string Name => name;
        [SerializeField] private string name;

        public Sprite Icon => icon;
        [SerializeField] private Sprite icon;

        public virtual string Description => description;
        [TextArea(3, 10)] [SerializeField] protected string description;
    }
}