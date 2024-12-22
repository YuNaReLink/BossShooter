using System;
using UnityEngine;

namespace CreateScript
{
    [System.Serializable]
    public class Timer
    {
        public event Action OnEnd;
        public event Action OnceEnd;

        private float current = 0;

        public float Current => current;

        public void Start(float time)
        {
            current = time;
        }

        public void Update(float time)
        {
            if (current <= 0) { return; }
            current -= time;
            if (current <= 0)
            {
                current = 0;
                End();
            }
        }

        public void End()
        {
            current = 0;
            OnceEnd?.Invoke();
            OnEnd?.Invoke();
            OnEnd = null;
        }

        public bool IsEnd() { return current <= 0; }
    }

}
