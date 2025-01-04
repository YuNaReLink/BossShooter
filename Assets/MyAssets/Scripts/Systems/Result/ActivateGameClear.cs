using UnityEngine;

namespace CreateScript
{
    //撃破タイプのゲームオーバー判定を行うクラス
    //アタッチしたオブジェクトが非表示になった時に処理を行う
    public class ActivateGameClear : MonoBehaviour
    {

        public void GameClearResult()
        {
            GameController.Instance.SetResult(ResultType.GameClear);
        }
    }
}
