using GameEvents;
using PoolsContainer;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PoolsContainer
{
    public class PoolObject : GameEventsMonoBehaviour
    {
        private Coroutine _backToPoolCoroutine;
        [HideInInspector] public Transform Parent;

        public Action OnBackToPoolEvent;
        public Action OnPrepareToBackToPoolEvent;

        public float LastTimeToBTP { get; protected set; }

        public void BackToPool(float time)
        {
            if (gameObject.activeInHierarchy)
            {
                if (_backToPoolCoroutine != null) StopCoroutine(_backToPoolCoroutine);
                _backToPoolCoroutine = StartCoroutine(Timer(time));
            }
            else backToPool();
        }

        public void StopTimer() => StopCoroutine(Timer());

        private IEnumerator Timer(float time = 0)
        {
            LastTimeToBTP = time;
            SendOnPrepareToBackToPoolEvent();
            yield return new WaitForSeconds(time);
            backToPool();
        }

        public void BackToPool()
        {
            LastTimeToBTP = 0f;
            SendOnPrepareToBackToPoolEvent();
            backToPool();
        }

        private void backToPool()
        {
            OnBackToPool();
            if (_backToPoolCoroutine != null) StopCoroutine(_backToPoolCoroutine);
            if (Parent) transform.SetParent(Parent);
            transform.localPosition = Vector3.zero;
            OnBackToPoolEvent?.Invoke();
            if (_backToPoolCoroutine != null) StopCoroutine(_backToPoolCoroutine);
            gameObject.SetActive(false);
        }

        public void BackToPool(Transform parent)
        {
            transform.SetParent(parent);
            LastTimeToBTP = 0;
            SendOnPrepareToBackToPoolEvent();
            backToPool();
        }

        protected virtual void OnBackToPool() { }
        protected void SendOnPrepareToBackToPoolEvent() => OnPrepareToBackToPoolEvent?.Invoke();
    }
}