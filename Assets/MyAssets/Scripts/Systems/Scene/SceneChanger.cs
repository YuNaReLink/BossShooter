using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreateScript
{
    /*
     * 各シーンのリスト
     */
    public enum SceneList
    {
        Title,
        Game,
        Result,

        Count
    }

    /*
     * シーン遷移の処理を行うシングルトンパターンのクラス
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
            yield return new WaitForSecondsRealtime(changeCount); // 1フレーム待つ
            GlobalManager.Instance.CreateFadePanel(false);
            isTransitioning = true;
        }

        private void Awake()
        {
            instance = this;
        }
        /*
         * ここで各シーンの名前をリスト別に取得
         * 引数１：SceneList scene 取得したシーンの名前を取得
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
            //isTransitioning = false;
        }
        //指定したcount後にシーンを遷移するメソッド
        private System.Collections.IEnumerator ChangeStart()
        {
            yield return new WaitForSecondsRealtime(changeCount); // 1フレーム待つ
            ChangeScene();
        }
    }
}
