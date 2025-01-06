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
        //現在のカウントを保持する変数
        private float current = 0;
        //ループ時に使う変数
        private float time = 0;
        //終了時のカウント
        private float endTime = 0;

        public float Current => current;
        //タイマーをループさせるかのフラグ
        private bool loop = false;
        public void SetLoop(bool l) { loop = l; }
        //タイマーをスタートさせる関数
        public void Start(float _time)
        {
            current = _time;
            time = _time;
        }
        //タイマーのカウントを追加する関数
        public void AddCurrent(float _time)
        {
            current += _time;
        }
        //タイマーの更新処理
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
        //タイマーが終わった時に行う処理
        public void End()
        {
            OnEnd?.Invoke();
            OnOnceEnd?.Invoke();
            OnOnceEnd = null;
        }
        //タイマーが終わったかどうかを判定
        public bool IsEnd() { return current <= endTime; }
    }

}
