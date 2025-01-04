using UnityEngine;

namespace CreateScript
{
    /*
     * �^�C�g���V�[���̊Ǘ�������N���X
     * ���݂̓X�R�A�̃��Z�b�g�ƃQ�[�����[�h��ύX���Ă邾��
     */
    public class TitleController : MonoBehaviour
    {

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameMode.Title);
            ScoreSystem.Instance.ResetScore();
        }
    }
}
