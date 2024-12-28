using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreateScript
{
    /// <summary>
    /// 各シーンのリスト
    /// </summary>
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
        /// ここで各シーンの名前をリスト別に取得
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
        //取得したシーンへ遷移
        public void ChangeScene()
        {
            SceneManager.LoadScene(GetSceneName(nextScene));
        }

        //シーン遷移ボタンを決定した時に呼び出されるメソッド
        public void OnChangeScene()
        {
            if(instance == null) { return; }
            StartCoroutine(ChangeStart());
        }
        //指定したcount後にシーンを遷移するメソッド
        private System.Collections.IEnumerator ChangeStart()
        {
            yield return new WaitForSecondsRealtime(changeCount); // 1フレーム待つ
            ChangeScene();
        }
    }
}
