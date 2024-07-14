using UnityEngine;

namespace InventorySystem.Core.Data
{
    public abstract class ISDataJsonPlayerPrefs<T> : ISData<T> where T : ItemSave
    {
        protected abstract string SavePath { get; }

        protected override void Save(T[] save)
        {
            string json = JsonUtility.ToJson(new SaveJson<T>(save));
            PlayerPrefs.SetString(SavePath, json);
        }

        protected override T[] Load()
        {
            string json = PlayerPrefs.GetString(SavePath, GetDefaultPackJSON());
            SaveJson<T> saveJson = JsonUtility.FromJson<SaveJson<T>>(json);
            return saveJson.Items;
        }

        protected string GetDefaultPackJSON()
        {
            SaveJson<T> saveJson = new SaveJson<T>(Default());
            return JsonUtility.ToJson(saveJson);
        }
        
        public override void ClearSaves() => Save(null);


        [System.Serializable]
        public struct SaveJson<Y> where Y : ItemSave
        {
            public SaveJson(Y[] items) => Items = items;

            public Y[] Items;
        }
    }
}