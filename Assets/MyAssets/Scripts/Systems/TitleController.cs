using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// タイトルシーンの管理をするクラス
    /// 現在はスコアのリセットとゲームモードを変更してるだけ
    /// </summary>
    public class TitleController : MonoBehaviour
    {

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameMode.Title);
            ScoreSystem.Instance.ResetScore();
        }
    }
}
