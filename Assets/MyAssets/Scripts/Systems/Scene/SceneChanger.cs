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
    /// シーン遷移の処理を行うシングルトンパターンのクラス
    /// </summary>
    public class SceneChanger : MonoBehaviour
    {
        private static SceneChanger     instance;
        public static SceneChanger      Instance => instance;

        private Timer                   sceneChangeTimer = new Timer();

        private SceneList               nextScene;

        public void SetNextScene(SceneList scene)
        {
            nextScene = scene;
        }

        [SerializeField]
        private float                   changeCount = 3f;

        private void Awake()
        {
            instance = this;

            sceneChangeTimer.OnceEnd += ChangeScene;
        }

        private void Update()
        {
            sceneChangeTimer.Update(Time.deltaTime);
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

        public void ReadySceneChange()
        {
            if (!sceneChangeTimer.IsEnd()) { return; }
            sceneChangeTimer.Start(changeCount);
        }
    }
}
