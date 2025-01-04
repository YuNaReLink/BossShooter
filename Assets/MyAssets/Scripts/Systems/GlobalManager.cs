using Unity.Collections;
using UnityEngine;

namespace CreateScript
{
    //現在がどのシーンなのかを各シーンの管理クラスで設定するもの
    public enum GameMode
    {
        Null = -1,
        Title,
        Game,
        Result
    }
    //結果画面でのOverかClearかを判定する
    public enum ResultType
    {
        GameOver,
        GameClear
    }
    /*
     * 全てのシーンのオブジェクト管理を行うクラス
     * シングルトンパターンでDontDestroyOnLoadにしてシーンをまたいで処理を行う
     */
    public class GlobalManager : MonoBehaviour
    {
        private static GlobalManager    instance;
        public static GlobalManager     Instance => instance;

        [SerializeField]
        [ReadOnly]
        private GameMode                gameMode;
        public GameMode                 GameMode => gameMode;

        //ゲームを止めるフラグ
        private bool gameStop = false;
        public bool IsGameStop => gameStop || Time.timeScale <= 0;

        //ゲームを止めるbool型を外部から設定するメソッド
        public void SetGameStop(bool b) { gameStop = b; }

        public void SetGameMode(GameMode mode)
        {
            gameMode = mode;
        }

        [SerializeField]
        private ResultType              resultType;
        public ResultType               ResultType => resultType;

        public void SetResultType(ResultType type)
        {
            resultType = type;
        }

        private Canvas canvas;
        public Canvas Canvas
        {
            get 
            {
                if(canvas == null)
                {
                    canvas = FindObjectOfType<Canvas>();
                }
                return canvas;
            }
        }

        [SerializeField]
        private FadePanel fadePanel;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void CreateFadePanel(bool fadein)
        {
            FadePanel panel = Instantiate(fadePanel, Canvas.transform);

            float alpha = 1f;
            if (fadein)
            {
                alpha = 0f;
            }
            panel.SetTargetAlpha(alpha);
        }
    }
}

