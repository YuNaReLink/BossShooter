using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreateScript
{
    /*
     * �e�V�[���̃��X�g
     */
    public enum SceneList
    {
        Title,
        Game,
        Result,

        Count
    }

    /*
     * �V�[���J�ڂ̏������s���V���O���g���p�^�[���̃N���X
     */
    public class SceneChanger : MonoBehaviour
    {
        private static SceneChanger     instance;
        public static SceneChanger      Instance => instance;

        private bool                    isTransitioning = false;
        public bool                     IsTransitioning => isTransitioning;

        private SceneList               nextScene;


        public void SetNextScene(SceneList scene)
        {
            nextScene = scene;
            isTransitioning = true;
            GlobalManager.Instance.CreateFadePanel(false);
        }

        [SerializeField]
        private float                   changeCount = 3f;

        public void SlowSceneChange(SceneList scene,float count)
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

        private void Awake()
        {
            instance = this;
        }
        /*
         * �����Ŋe�V�[���̖��O�����X�g�ʂɎ擾
         * �����P�FSceneList scene �擾�����V�[���̖��O���擾
         */
        private string GetSceneName(SceneList scene)
        {
            string temp;

            switch (scene)
            {
                case SceneList.Title:
                    temp = "TitleScene";
                    break;
                case SceneList.Game:
                    temp = "GameScene";
                    break;
                case SceneList.Result:
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
    }
}
