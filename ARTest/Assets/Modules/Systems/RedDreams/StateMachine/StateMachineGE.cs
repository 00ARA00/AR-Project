using GameEvents;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachineGE : GameEventsMonoBehaviour
    {
        protected Dictionary<Type, IBehaviour> behavioursMap;

        public IBehaviour CurrentBehaviour { get; protected set; }

        protected override void Awake()
        {
            base.Awake();
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

        protected virtual void Initialize() { }

        protected virtual void FixedUpdate()
        {
            CurrentBehaviour?.Update();
        }
    }
}