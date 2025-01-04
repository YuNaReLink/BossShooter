using UnityEngine;

namespace CreateScript
{
    /*
     * 画像で作成されたアニメーションエフェクトが
     * 最後まで再生されたら処理を行うクラス
     */
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
