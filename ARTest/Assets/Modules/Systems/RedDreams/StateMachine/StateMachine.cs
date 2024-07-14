using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected Dictionary<Type, IBehaviour> behavioursMap;
        
        public IBehaviour CurrentBehaviour { get; protected set; }

        private void Awake()
        {
            behavioursMap = new Dictionary<Type, IBehaviour>();
            Initialize();
        }

        public bool CheckBehaviour<T>() => behavioursMap.ContainsKey(typeof(T));
        
        public void AddBehaviour<T>(T behaviour) where T : IBehaviour
        {
            if (!behavioursMap.ContainsKey(typeof(T)))
                behavioursMap.Add(typeof(T), behaviour);
        }

        public T SetBehaviour<T>(bool force = false) where T : class, IBehaviour
        {
            if (CurrentBehaviour is not T || force)
            {
                CurrentBehaviour?.Exit();
                CurrentBehaviour = GetBehaviour<T>();
                CurrentBehaviour.Enter();
            }
            return CurrentBehaviour as T;
        }

        public T GetBehaviour<T>() where T : IBehaviour
        {
            return (T)behavioursMap[typeof(T)];
        }
        
        protected abstract void Initialize();

        protected virtual void FixedUpdate()
        {
            CurrentBehaviour?.Update();
        }
    }
}