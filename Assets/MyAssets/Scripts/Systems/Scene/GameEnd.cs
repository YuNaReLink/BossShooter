using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ゲームの実行を終了させる処理を行うクラス
    /// </summary>
    public class GameEnd : MonoBehaviour
    {
        private Timer gameEndTimer = new Timer();

        [SerializeField]
        private float endCount = 2f;

        private void Awake()
        {
            gameEndTimer.OnceEnd += End;
        }

        public void Update()
        {
            gameEndTimer.Update(Time.deltaTime);
        }

        public void ReadyEnd()
        {
            if (!gameEndTimer.IsEnd()) { return; }
            gameEndTimer.Start(endCount);
        }

        private void End()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
            //ゲームプレイ終了
            Application.Quit();
#endif
        }
    }
}
