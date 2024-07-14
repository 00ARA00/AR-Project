using System.Collections;
using UnityEngine;
using PoolsContainer.Core;
using System;

namespace PoolsContainer.Core
{
    public abstract class MonoSingleContainer<T> : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] poolsMono;

        public event Action<T> OnCreated;
        public T[] Objects => container.Objects;

        protected Container<T> container;

        protected virtual void Awake()
        { 
            container = new Container<T>();
            container.OnCreated += created;

            for (int i = 0; i < poolsMono.Length; i++)
            {
                if (poolsMono[i].TryGetComponent(out IObjectCreator<T> creator))
                {
                    container.AddCreator(creator);
                }
            }
        }

        protected virtual void OnDestroy()
        {
            container.OnCreated -= Created;
            container.Clear();
        }

        private void created(T obj)
        {
            OnCreated?.Invoke(obj);
            Created(obj);
        }
        protected abstract void Created(T obj);
    }
}