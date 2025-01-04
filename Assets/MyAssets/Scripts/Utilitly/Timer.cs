using System;

namespace CreateScript
{
    /*
     * 全クラスで生成して共通で使えるタイマークラス
     */
    [System.Serializable]
    public class Timer
    {
        //タイマーが終わった時に一度だけ実行させるAction
        public event Action     OnEnd;
        //タイマー終了時に何回でも呼び出されるAction
        public event Action     OnOnceEnd;

        private float current = 0;

        private float time = 0;

        private float endTime = 0;

        public float Current => current;

        private bool loop = false;
        public void SetLoop(bool l) { loop = l; }

        public void Start(float _time)
        {
            current = _time;
            time = _time;
        }

        public void AddCurrent(float _time)
        {
            current += _time;
        }

        public void Update(float t)
        {
            if (current <= endTime) { return; }
            current -= t;
            if (current <= endTime)
            {
                if (loop)
                {
                    current += time;
                }
                End();
            }
        }

        public void End()
        {
            OnEnd?.Invoke();
            OnOnceEnd?.Invoke();
            OnOnceEnd = null;
        }

        public bool IsEnd() { return current <= endTime; }
    }

}
