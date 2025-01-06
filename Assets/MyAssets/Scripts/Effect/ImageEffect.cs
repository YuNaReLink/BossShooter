using UnityEngine;

namespace CreateScript
{
    /*
     * �摜�ō쐬���ꂽ�A�j���[�V�����G�t�F�N�g��
     * �Ō�܂ōĐ����ꂽ�珈�����s���N���X
     */
    public class ImageEffect : MonoBehaviour
    {
        private Animator            animator;
        //�A�j���[�V�����̏ڍׂȏ����擾���邽�߂̐錾
        private AnimatorStateInfo   animInfo => animator.GetCurrentAnimatorStateInfo(0);

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            if (AnimationEndChack())
            {
                //�I����Ă�����폜
                Destroy(gameObject);
            }
        }
        //�A�j���[�V�������I����Ă邩�𔻒�
        private bool AnimationEndChack()
        {
            if(animInfo.normalizedTime >= 1.0f)
            {
                return true;
            }
            return false;
        }
    }
}
