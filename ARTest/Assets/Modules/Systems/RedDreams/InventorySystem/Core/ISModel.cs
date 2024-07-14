using InventorySystem.Core.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Core
{
    public class ISModel<T> where T : ItemSave
    {
        public T[] ItemSaves => _itemSaves.ToArray();
        private List<T> _itemSaves;

        private T[] data
        {
            get => _inventoryData.ItemsSave;
            set
            {
                _inventoryData.ItemsSave = value;
                OnItemSavesChanged?.Invoke();
            }
        }

        private readonly ISData<T> _inventoryData;
        public Action OnItemSavesChanged;

        public ISModel(ISData<T> data)
        {
            _inventoryData = data;
            _itemSaves = new List<T>(this.data);
        }

        public bool TryGetItemSaveByIndex(int index, out T itemSave)
        {
            itemSave = _itemSaves.Count > index && index != -1 ? _itemSaves[index] : null;
            return itemSave != null;
        }

        public bool TryGetItemSaveByID(int id, out T itemSave)
        {
            TryFindItemDataByID(id, out int index);
            TryGetItemSaveByIndex(index, out itemSave);
            return itemSave != null;
        }

        public bool TryGetItemSaveByItem(T item, out T itemSave)
        {
            TryFindEquialItemData(item, out int index);
            if (index == -1)
            {
                Debug.LogError(string.Format("Can't Find Item {0}, int data", item.ID));
                itemSave = null;
                return false;
            }
            TryGetItemSaveByIndex(index, out itemSave);
            return itemSave != null;
        }

        public T AddItemSave(int id, int count) => AddItemSave(new ItemSave(id, count) as T);
        public T AddItemSave(T item)
        {
            if (TryFindEquialItemData(item, out int index)) _itemSaves[index].Count += item.Count;
            else _itemSaves.Add(item);
            SaveTempToData();
            return item;
        }

        public void RemoveItem(T item, int count)
        {
            if (TryFindEquialItemData(item, out int index)) RemoveItemByIndex(index, count);
        }
        public void RemoveItemByID(int id, int count)
        {
            if (TryFindItemDataByID(id, out int index)) RemoveItemByIndex(index, count);
        }
        public void RemoveItemByIndex(int index, int count)
        {
            if (_itemSaves == null) return;
            if (_itemSaves.Count <= index) return;

            if (_itemSaves[index].Count > count) _itemSaves[index].Count -= count;
            else DeleteItem(index);
            SaveTempToData();
        }

        private void DeleteItem(int index) => _itemSaves.RemoveAt(index);

        private bool TryFindItemDataByID(int ID, out int index)
        {
            index = -1;
            for (int i = 0; i < _itemSaves.Count; i++)
            {
                if (_itemSaves[i].ID == ID)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        private bool TryFindEquialItemData(T item, out int index)
        {
            index = -1;
            for (int i = 0; i < _itemSaves.Count; i++)
            {
                if (_itemSaves[i].Equals(item))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public void SaveTempToData() => data = _itemSaves.ToArray();
    }
}