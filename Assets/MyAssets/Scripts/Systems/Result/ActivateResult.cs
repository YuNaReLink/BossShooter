using UnityEngine;

namespace CreateScript
{
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
        private void OnDisable()
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
            SceneChanger.Instance.SetNextScene(SceneList.Result);
            SceneChanger.Instance.ReadySceneChange();
        }
    }
}
