using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreateScript
{
    /// <summary>
    /// �e�V�[���̃��X�g
    /// </summary>
    public enum SceneList
    {
        Title,
        Game,
        Result,

        Count
    }

    /// <summary>
    /// �V�[���J�ڂ̏������s���V���O���g���p�^�[���̃N���X
    /// </summary>
    public class SceneChanger : MonoBehaviour
    {
        private static SceneChanger     instance;
        public static SceneChanger      Instance => instance;

        private SceneList               nextScene;

        public void SetNextScene(SceneList scene)
        {
            nextScene = scene;
        }

        [SerializeField]
        private float                   changeCount = 3f;

        public void SetChangeCount(float count)
        {
            changeCount = count;
        }

        private void Awake()
        {
            instance = this;
        }
        /// <summary>
        /// �����Ŋe�V�[���̖��O�����X�g�ʂɎ擾
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
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
        }
        //�w�肵��count��ɃV�[����J�ڂ��郁�\�b�h
        private System.Collections.IEnumerator ChangeStart()
        {
            yield return new WaitForSecondsRealtime(changeCount); // 1�t���[���҂�
            ChangeScene();
        }
    }
}
