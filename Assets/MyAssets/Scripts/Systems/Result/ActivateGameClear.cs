using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ���j�^�C�v�̃Q�[���I�[�o�[������s���N���X
    /// �A�^�b�`�����I�u�W�F�N�g����\���ɂȂ������ɏ������s��
    /// </summary>
    public class ActivateGameClear : MonoBehaviour
    {

        public void GameClearResult()
        {
            GameController.Instance.SetResult(ResultType.GameClear);
        }
    }
}