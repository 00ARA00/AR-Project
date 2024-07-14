using System;
using System.Collections.Generic;

namespace PoolsContainer.Core
{
    public class Container<T>
    {
        public T[] Objects => _objects.ToArray();

        public event Action<T> OnCreated;

        private List<IObjectCreator<T>> _creators;
        private List<T> _objects;

        public Container()
        {
            _creators = new List<IObjectCreator<T>>();
            _objects = new List<T>();
        }

        public Container(params IObjectCreator<T>[] creators) : this() => AddCreators(creators);

        public void AddCreators(IObjectCreator<T>[] creators)
        {
            for (int i = 0; i < creators.Length; i++)
                AddCreator(creators[i]);
        }

        public void AddCreator(IObjectCreator<T> creator)
        {
            _creators.Add(creator);
            creator.OnCreated += OnObjectCreated;
        }

        public void Clear()
        {
            for (int i = 0; i < _creators.Count; i++)
            {
                _creators[i].OnCreated -= OnObjectCreated;
            }
        }

        private void OnObjectCreated(T obj)
        {
            OnCreated?.Invoke(obj);
            _objects.Add(obj);
        }
    }
}