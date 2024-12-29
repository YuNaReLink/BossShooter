using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 遷移するシーンを設定するクラス
    /// ボタンに設定して押されたときにシーンを設定
    /// </summary>
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
