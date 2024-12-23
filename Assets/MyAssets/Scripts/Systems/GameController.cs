using UnityEngine;

namespace CreateScript
{

    public class GameController : MonoBehaviour
    {
        private static GameController instance;
        public static GameController Instance => instance;


        [SerializeField]
        private int playerRemainingLives;

        [SerializeField]
        private int bombCount;
        public int BombCount => bombCount;
        public void DecreaseBombCount()
        {
            bombCount--;
            if(bombCount <= 0)
            {
                bombCount = 0;
            }
        }

        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private PlayerController currentPlayer;

        private Timer revivalTimer = new Timer();

        private bool gameStop = false;
        public bool IsGameStop => gameStop;
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

        void Start()
        {
            gameStop = true;

            GlobalManager.Instance.SetGameMode(GameMode.Game);
        }

        // Update is called once per frame
        private void Update()
        {
            revivalTimer.Update(Time.deltaTime);

            PlayerCheck();
        }

        private void PlayerCheck()
        {
            if (currentPlayer != null||!revivalTimer.IsEnd()||
                playerRemainingLives <= 0) { return; }
            revivalTimer.Start(3f);
        }

        public void RevivalPlayer()
        {
            playerRemainingLives--;
            if(playerRemainingLives <= 0)
            {
                GlobalManager.Instance.SetResultType(ResultType.GameOver);
                GameUIController.Instance.CreateResultText("GAMEOVER");
                SceneChanger.Instance.SetNextScene(SceneList.Result);
                SceneChanger.Instance.ReadySceneChange();
            }
            else
            {
                GameObject g = Instantiate(playerController.gameObject,playerController.gameObject.transform.position,Quaternion.identity);
                currentPlayer = g.GetComponent<PlayerController>();
                gameStop = true;
            }
        }
    }
}
