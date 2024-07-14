using InventorySystem.Core.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Core
{
    public abstract class ISViewModel<D, S, C> where S : ItemSave where D : ISData<S> where C : ISContainer
    {
        public ISViewModel()
        {
            Model = new ISModel<S>(CreateData());
            Container = CreateContainer();

            Model.OnItemSavesChanged += () => { OnItemsChanged?.Invoke(); };
        }

        protected readonly ISModel<S> Model;
        protected readonly C Container;

        protected abstract D CreateData();
        protected abstract C CreateContainer();

        public event Action OnItemsChanged;

        public ISModel<S> InventorySave => Model;
        public C ItemsContainer => Container;

        public ItemInfo<S, I>[] GetAllItems<I>() where I : Item
        {
            return GetItemsByItemSave<I>(Model.ItemSaves);
        }

        public ItemInfo<S, I>[] GetItemsByItemSave<I>(params S[] itemSaves) where I : Item
        {
            List<ItemInfo<S, I>> items = new List<ItemInfo<S, I>>();

            I item;
            for (int i = 0; i < itemSaves.Length; i++)
            {
                item = Container.GetItemById<I>(itemSaves[i].ID);
                items.Add(new ItemInfo<S, I>() { Save = itemSaves[i], Item = item });
            }

            return items.ToArray();
        }

        public ItemInfo<NS, I>[] TryFindItemSavesByItemData<NS, I>(params I[] itemsData) where NS : S where I : Item
        {
            List<ItemInfo<NS, I>> items = new List<ItemInfo<NS, I>>();

            for (int i = 0; i < itemsData.Length; i++)
                if (Model.TryGetItemSaveByID(itemsData[i].ID, out S outSave))
                    if (outSave is NS save)
                        items.Add(new ItemInfo<NS, I>() { Save = save, Item = itemsData[i] });

            return items.ToArray();
        }

        public bool TryGetShortItemInfo(int index, out Item item, out int count)
        {
            item = null;
            count = 0;

            if (Model.TryGetItemSaveByIndex(index, out S save))
            {
                item = Container.GetItemById(save.ID);
                count = save.Count;
                return true;
            }
            return false;
        }
    }

    public struct ItemInfo<S, I> where S : ItemSave where I : Item
    {
        public S Save;
        public I Item;
    }
}