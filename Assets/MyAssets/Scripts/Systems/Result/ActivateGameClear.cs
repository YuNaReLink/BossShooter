using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 撃破タイプのゲームオーバー判定を行うクラス
    /// アタッチしたオブジェクトが非表示になった時に処理を行う
    /// </summary>
    public class ActivateGameClear : MonoBehaviour
    {

        public void GameClearResult()
        {
            GameController.Instance.SetResult(ResultType.GameClear);
        }
    }
}
