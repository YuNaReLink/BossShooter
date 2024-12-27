using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ���j�^�C�v�̃Q�[���I�[�o�[������s���N���X
    /// �A�^�b�`�����I�u�W�F�N�g����\���ɂȂ������ɏ������s��
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
