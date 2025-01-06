using UnityEngine;

namespace CreateScript
{
    //現在がどのシーンなのかを各シーンの管理クラスで設定するもの
    public enum GameScene
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
        private static GlobalManager        instance;
        public static GlobalManager         Instance => instance;

        [SerializeField]
        private GameScene                   gameScene;

        //ゲームを止めるフラグ
        private bool                        gameStop = false;
        public bool                         IsGameStop => gameStop || Time.timeScale <= 0;


        [SerializeField]
        private ResultType                  resultType;
        public ResultType                   ResultType => resultType;

        private Canvas                      canvas;

        [SerializeField]
        private FadePanel                   fadePanel;

        //ゲームを止めるbool型を外部から設定するメソッド
        public void SetGameStop(bool b) { gameStop = b; }

        public void SetGameMode(GameScene mode)
        {
            gameScene = mode;
        }

        public void SetResultType(ResultType type)
        {
            resultType = type;
        }
        //キャンバスを取得するpublic関数
        //キャンバスがない場合は自動で取得する
        public Canvas Canvas
        {
            get
            {
                if (canvas == null)
                {
                    canvas = FindObjectOfType<Canvas>();
                }
                return canvas;
            }
        }
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
        //フェードパネルを作成する関数
        //引数のbool型によってゴールalpha値を代入
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

