using UnityEngine;

namespace CreateScript
{
    /*
     * ゲームシーンで全体的に使う処理を行うクラス
     */
    public class GameController : MonoBehaviour
    {
        private static GameController       instance;
        public static GameController        Instance => instance;

        //プレイヤーの残機カウント
        [SerializeField]
        private int                         playerRemainingLives;
        public int                          PlayerLife => playerRemainingLives;
        //ボムのカウントを行う変数
        [SerializeField]
        private int                         bombCount;
        public int                          BombCount => bombCount;
        //プレハブからセットし復帰時に生成する用のPlayer
        [SerializeField]
        private PlayerController            playerController;
        //ゲーム開始時、生成時にプレイヤーがゲームシーンにいるかを確認する用のPlayer
        [SerializeField]
        private PlayerController            currentPlayer;
        //プレイヤーが復帰出来るまでのタイマー
        private Timer                       revivalTimer = new Timer();

        //ボムのカウントを減らすメソッド
        public void DecreaseBombCount()
        {
            bombCount--;
            if(bombCount <= 0)
            {
                bombCount = 0;
            }
        }

        public void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            revivalTimer.OnEnd += RevivalPlayer;

            currentPlayer = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameMode.Game);
        }


        private void Update()
        {
            revivalTimer.Update(Time.deltaTime);

            PlayerCheck();
        }
        //残機があり、プレイヤーが存在しなかったら復活カウント開始
        private void PlayerCheck()
        {
            if (currentPlayer != null||!revivalTimer.IsEnd()||
                playerRemainingLives < 0) { return; }
            revivalTimer.Start(3f);
        }
        //残機があれば復活、なければゲームオーバー
        public void RevivalPlayer()
        {
            playerRemainingLives--;
            if(playerRemainingLives < 0)
            {
                SetResult(ResultType.GameOver);
            }
            else
            {
                GameObject g = Instantiate(playerController.gameObject,playerController.gameObject.transform.position,Quaternion.identity);
                currentPlayer = g.GetComponent<PlayerController>();
            }
        }

        private string SetGameResult()
        {
            string result = "";
            if (playerRemainingLives >= 0)
            {
                result = "GAMECLEAR";
            }
            else
            {
                result = "GAMEOVER";
            }
            return result;
        }
        //結果のenum別に結果画面に遷移させる
        public void SetResult(ResultType type)
        {
            GlobalManager.Instance.SetResultType(type);
            GameUIController.Instance.CreateResultText(SetGameResult());
            SceneChanger.Instance?.SlowSceneChange(SceneList.Result,2f);
            BGMManager.Stop();
        }
    }
}
