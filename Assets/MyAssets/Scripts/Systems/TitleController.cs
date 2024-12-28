using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �^�C�g���V�[���̊Ǘ�������N���X
    /// ���݂̓X�R�A�̃��Z�b�g�ƃQ�[�����[�h��ύX���Ă邾��
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
