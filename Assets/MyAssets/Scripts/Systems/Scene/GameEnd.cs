using UnityEngine;

namespace CreateScript
{
    /*
     * ゲームの実行を終了させる処理を行うクラス
     */
    public class GameEnd : MonoBehaviour
    {

        [SerializeField]
        private float endCount = 2f;

        //ボタンのUnityEventに設定
        private void ReadyEnd()
        {
            StartCoroutine(End());
        }
        private System.Collections.IEnumerator End()
        {
            yield return new WaitForSecondsRealtime(endCount); // 1フレーム待つ
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
            //ゲームプレイ終了
            Application.Quit();
#endif
        }
    }
}
