using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �摜�ō쐬���ꂽ�A�j���[�V�����G�t�F�N�g��
    /// �Ō�܂ōĐ����ꂽ�珈�����s���N���X
    /// </summary>
    public class ImageEffect : MonoBehaviour
    {
        [SerializeField]
        private Animator            animator;

        private AnimatorStateInfo   animInfo => animator.GetCurrentAnimatorStateInfo(0);

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            if (AnimationEndChack())
            {
                Destroy(gameObject);
            }
        }

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
