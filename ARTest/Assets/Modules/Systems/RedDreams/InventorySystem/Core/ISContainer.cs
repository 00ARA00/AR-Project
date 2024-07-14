using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem.Core
{
    public abstract class ISContainer
    {
        public Item[] AllItems { get; private set; }
        private readonly Dictionary<int, Item> _itemsMap;

        protected abstract string[] ItemDataScrObjPaths { get; }

        public ISContainer()
        {
            _itemsMap = new Dictionary<int, Item>();
            LoadItemData();
        }

        public Item[] GetItemById(int[] id)
        {
            List<Item> items = new List<Item>();

            for (int i = 0; i < id.Length; i++)
                if (_itemsMap.ContainsKey(id[i])) items.Add(_itemsMap[id[i]]);

            return items.ToArray();
        }

        public bool CheckItemById(int id) => _itemsMap.ContainsKey(id);
        
        public Item GetItemById(int id) => _itemsMap.ContainsKey(id) ? _itemsMap[id] : null;
        
        public T GetItemById<T>(int id) where T : Item => _itemsMap[id] as T; //TODO!!!!

        public Item[] GetItemsByCategory(ItemsCategories category)
        {
            List<Item> temp = new List<Item>();
            for (int i = 0; i < AllItems.Length; i++)
                if (AllItems[i].Category == category) temp.Add(_itemsMap[i]);

            return temp.ToArray();
        }

        public T[] GetItemsByCategory<T>(ItemsCategories category) where T : Item
        {     
            List<T> temp = new List<T>();
            T[] items = GetItemsOfType<T>();

            for (int i = 0; i < items.Length; i++)
                if (items[i].Category == category) temp.Add(items[i]);

            return temp.ToArray();
        }


        public T[] GetItemsOfType<T>() where T : Item
        {
            List<T> temp = new List<T>();
            for (int i = 0; i < AllItems.Length; i++)
            {
                if (AllItems[i] is T item) temp.Add(item);
            }

            return temp.ToArray();
        }

        protected virtual void LoadItemData()
        {
            List<Item> tempItems = new List<Item>();
            _itemsMap.Clear();
            for (int i = 0; i < ItemDataScrObjPaths.Length; i++)
            {
                var temp = Resources.LoadAll<ItemScrObjBase>(ItemDataScrObjPaths[i]);
                AllItems = new Item[temp.Length];
                int id;

                for (int j = 0; j < temp.Length; j++)
                {
                    AllItems[j] = temp[j].Item;

                    id = temp[j].Item.ID;
                    if (!_itemsMap.ContainsKey(id))
                    {
                        _itemsMap.Add(id, temp[j].Item);
                    }
                    else Debug.LogError("ItemDataContainer found 2 items with one ID's!");
                }
                tempItems.AddRange(AllItems);
            }

            AllItems = tempItems.ToArray();
        }
    }
}

