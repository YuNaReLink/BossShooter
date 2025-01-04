using Unity.Collections;
using UnityEngine;

namespace CreateScript
{
    //���݂��ǂ̃V�[���Ȃ̂����e�V�[���̊Ǘ��N���X�Őݒ肷�����
    public enum GameMode
    {
        Null = -1,
        Title,
        Game,
        Result
    }
    //���ʉ�ʂł�Over��Clear���𔻒肷��
    public enum ResultType
    {
        GameOver,
        GameClear
    }
    /*
     * �S�ẴV�[���̃I�u�W�F�N�g�Ǘ����s���N���X
     * �V���O���g���p�^�[����DontDestroyOnLoad�ɂ��ăV�[�����܂����ŏ������s��
     */
    public class GlobalManager : MonoBehaviour
    {
        private static GlobalManager    instance;
        public static GlobalManager     Instance => instance;

        [SerializeField]
        [ReadOnly]
        private GameMode                gameMode;
        public GameMode                 GameMode => gameMode;

        //�Q�[�����~�߂�t���O
        private bool gameStop = false;
        public bool IsGameStop => gameStop || Time.timeScale <= 0;

        //�Q�[�����~�߂�bool�^���O������ݒ肷�郁�\�b�h
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

