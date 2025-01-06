using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreateScript
{

    /*
     * �V�[���J�ڂ̏������s���V���O���g���p�^�[���̃N���X
     */
    public class SceneChanger : MonoBehaviour
    {
        private static SceneChanger     instance;
        public static SceneChanger      Instance => instance;
        //�J�ڒ����̃t���O
        private bool                    isTransitioning = false;
        public bool                     IsTransitioning => isTransitioning;
        //�J�ڐ�̃V�[����ێ�����ϐ�
        private GameScene               nextScene;
        //�J�ڂ���܂ł̃J�E���g
        [SerializeField]
        private float                   changeCount = 3f;


        private void Awake()
        {
            instance = this;
        }

        /*
         * �����Ŋe�V�[���̖��O�����X�g�ʂɎ擾
         * �����P�FSceneList scene �擾�����V�[���̖��O���擾
         */
        private string GetSceneName(GameScene scene)
        {
            string temp;

            switch (scene)
            {
                case GameScene.Title:
                    temp = "TitleScene";
                    break;
                case GameScene.Game:
                    temp = "GameScene";
                    break;
                case GameScene.Result:
                    temp = "ResultScene";
                    break;
                default:
                    temp = "TitleScene";
                    break;
            }
            return temp;
        }
        //�擾�����V�[���֑J��
        public void ChangeScene()
        {
            SceneManager.LoadScene(GetSceneName(nextScene));
        }

        //�V�[���J�ڃ{�^�������肵�����ɌĂяo����郁�\�b�h
        public void OnChangeScene()
        {
            if(instance == null) { return; }
            StartCoroutine(ChangeStart());
            //isTransitioning = false;
        }
        //�w�肵��count��ɃV�[����J�ڂ��郁�\�b�h
        private System.Collections.IEnumerator ChangeStart()
        {
            yield return new WaitForSecondsRealtime(changeCount); // 1�t���[���҂�
            ChangeScene();
        }
        //�V�[���J�ڂ��s������
        public void SetNextScene(GameScene scene)
        {
            nextScene = scene;
            isTransitioning = true;
            GlobalManager.Instance.CreateFadePanel(false);
        }

        //�������ƃV�[���J�ڂ����鏈��
        public void SlowSceneChange(GameScene scene, float count)
        {
            changeCount = count;
            nextScene = scene;
            StartCoroutine(SlowFade());
        }

        private System.Collections.IEnumerator SlowFade()
        {
            yield return new WaitForSecondsRealtime(changeCount); // 1�t���[���҂�
            GlobalManager.Instance.CreateFadePanel(false);
            isTransitioning = true;
        }
    }
}
