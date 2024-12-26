using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ゲームの実行を終了させる処理を行うクラス
    /// </summary>
    public class GameEnd : MonoBehaviour
    {

        [SerializeField]
        private float endCount = 2f;


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
