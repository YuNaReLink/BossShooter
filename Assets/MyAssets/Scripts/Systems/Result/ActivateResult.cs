using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 撃破タイプのゲームオーバー判定を行うクラス
    /// アタッチしたオブジェクトが非表示になった時に処理を行う
    /// </summary>
    public class ActivateResult : MonoBehaviour
    {
        [SerializeField]
        private bool gameClear = false;

        private string SetGameResult()
        {
            string result = "";
            if (gameClear)
            {
                result = "GAMECLEAR";
            }
            else
            {
                result = "GAMEOVER";
            }
            return result;
        } 

        public void GameOverResult()
        {
            if (gameClear)
            {
                GlobalManager.Instance.SetResultType(ResultType.GameClear);
            }
            else
            {
                GlobalManager.Instance.SetResultType(ResultType.GameOver);
            }
            GameUIController.Instance.CreateResultText(SetGameResult());
            SceneChanger.Instance?.SetNextScene(SceneList.Result);
            SceneChanger.Instance?.SetChangeCount(5f);
            SceneChanger.Instance?.OnChangeScene();
        }
    }
}
