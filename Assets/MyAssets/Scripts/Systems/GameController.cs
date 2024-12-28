using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ゲームシーンで全体的に使う処理を行うクラス
    /// </summary>
    public class GameController : MonoBehaviour
    {
        private static GameController       instance;
        public static GameController        Instance => instance;


        [SerializeField]
        private int                         playerRemainingLives;
        public int                          PlayerLife => playerRemainingLives;

        [SerializeField]
        private int                         bombCount;
        public int                          BombCount => bombCount;

        [SerializeField]
        private PlayerController            playerController;

        [SerializeField]
        private PlayerController            currentPlayer;

        private Timer                       revivalTimer = new Timer();

        private bool                        gameStop = false;
        public bool                         IsGameStop => gameStop;
        public void DecreaseBombCount()
        {
            bombCount--;
            if(bombCount <= 0)
            {
                bombCount = 0;
            }
        }
        public void SetGameStop(bool b) { gameStop = b; }

        public void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            revivalTimer.OnceEnd += RevivalPlayer;

            currentPlayer = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            gameStop = true;

            GlobalManager.Instance.SetGameMode(GameMode.Game);
        }


        private void Update()
        {
            revivalTimer.Update(Time.deltaTime);

            PlayerCheck();
        }

        private void PlayerCheck()
        {
            if (currentPlayer != null||!revivalTimer.IsEnd()||
                playerRemainingLives < 0) { return; }
            revivalTimer.Start(3f);
        }

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
                gameStop = true;
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

        public void SetResult(ResultType type)
        {
            GlobalManager.Instance.SetResultType(type);
            GameUIController.Instance.CreateResultText(SetGameResult());
            SceneChanger.Instance?.SetNextScene(SceneList.Result);
            SceneChanger.Instance?.SetChangeCount(5f);
            SceneChanger.Instance?.OnChangeScene();
        }
    }
}
