using UnityEngine;

namespace CreateScript
{
    /*
     * タイトルシーンの管理をするクラス
     * 現在はスコアのリセットとゲームモードを変更してるだけ
     */
    public class TitleController : MonoBehaviour
    {

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameScene.Title);
            ScoreSystem.Instance.ResetScore();
        }
    }
}
