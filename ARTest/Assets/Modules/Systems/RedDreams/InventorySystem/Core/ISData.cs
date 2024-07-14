namespace InventorySystem.Core.Data
{
    public abstract class ISData<T> where T : ItemSave
    {
        public T[] ItemsSave
        {
            get => Load();
            set => Save(value);
        }

        public abstract void ClearSaves();

        protected virtual T[] Default() => new T[] { };

        protected abstract void Save(T[] save);

        protected abstract T[] Load();
    }
}