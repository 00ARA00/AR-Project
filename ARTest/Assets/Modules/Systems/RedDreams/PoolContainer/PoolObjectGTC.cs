using GTC;
using UnityEngine;

namespace PoolsContainer
{
    public class PoolObjectGTC : PoolObject
    {
        private Timer _timer;

        private const string Key = "GTC";

        public void BackToPoolGTC(GameTimeController gameTimeController, float time)
        { 
            LastTimeToBTP = time;
            SendOnPrepareToBackToPoolEvent();
            if (gameObject.activeInHierarchy)
            {
                if (_timer == null)
                { 
                    _timer = gameTimeController.CreateCustomTimer(gameObject.GetInstanceID() + Key, TimerType.Pause);
                    _timer.OnTimerEnd += BackToPool;
                }
                _timer.StartTimer(time);
            }
            else BackToPool();
        }

        public void StopTimerGTC()
        {
            if (_timer != null) _timer.Stop();
        }

        protected override void OnBackToPool()
        {
            if (_timer != null) _timer.Stop();
            base.OnBackToPool();
        }
    }
}