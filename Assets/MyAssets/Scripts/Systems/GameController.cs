using UnityEngine;

namespace CreateScript
{
    /*
     * �Q�[���V�[���őS�̓I�Ɏg���������s���N���X
     */
    public class GameController : MonoBehaviour
    {
        private static GameController       instance;
        public static GameController        Instance => instance;

        //�v���C���[�̎c�@�J�E���g
        [SerializeField]
        private int                         playerRemainingLives;
        public int                          PlayerLife => playerRemainingLives;
        //�{���̃J�E���g���s���ϐ�
        [SerializeField]
        private int                         bombCount;
        public int                          BombCount => bombCount;
        //�v���n�u����Z�b�g�����A���ɐ�������p��Player
        [SerializeField]
        private PlayerController            playerController;
        //�Q�[���J�n���A�������Ƀv���C���[���Q�[���V�[���ɂ��邩���m�F����p��Player
        [SerializeField]
        private PlayerController            currentPlayer;
        //�v���C���[�����A�o����܂ł̃^�C�}�[
        private Timer                       revivalTimer = new Timer();

        //�{���̃J�E���g�����炷���\�b�h
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
        //�c�@������A�v���C���[�����݂��Ȃ������畜���J�E���g�J�n
        private void PlayerCheck()
        {
            if (currentPlayer != null||!revivalTimer.IsEnd()||
                playerRemainingLives < 0) { return; }
            revivalTimer.Start(3f);
        }
        //�c�@������Ε����A�Ȃ���΃Q�[���I�[�o�[
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
        //���ʂ�enum�ʂɌ��ʉ�ʂɑJ�ڂ�����
        public void SetResult(ResultType type)
        {
            GlobalManager.Instance.SetResultType(type);
            GameUIController.Instance.CreateResultText(SetGameResult());
            SceneChanger.Instance?.SlowSceneChange(SceneList.Result,2f);
            BGMManager.Stop();
        }
    }
}
