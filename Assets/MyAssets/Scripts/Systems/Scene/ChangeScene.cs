using UnityEngine;

namespace CreateScript
{
    /*
     * 遷移するシーンを設定するクラス
     * ボタンに設定して押されたときにシーンを設定
     */
    public class ChangeScene : MonoBehaviour
    {
        //ここに設定したシーンをSceneChangerに設定
        [SerializeField]
        private SceneList nextScene;

        public void SetNextScene()
        {
            SceneChanger.Instance.SetNextScene(nextScene);
        }
    }
}
