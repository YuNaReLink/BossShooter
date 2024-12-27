using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreateScript
{
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

        public void ChangeScene()
        {
            SceneManager.LoadScene(GetSceneName(nextScene));
        }

        //0.1�b��������V�[���J��
        public void OnChangeScene()
        {
            if(instance == null) { return; }
            StartCoroutine(ChangeStart());
        }
        private System.Collections.IEnumerator ChangeStart()
        {
            yield return new WaitForSecondsRealtime(changeCount); // 1�t���[���҂�
            ChangeScene();
        }
    }
}
