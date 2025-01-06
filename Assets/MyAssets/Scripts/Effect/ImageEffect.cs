using UnityEngine;

namespace CreateScript
{
    /*
     * 画像で作成されたアニメーションエフェクトが
     * 最後まで再生されたら処理を行うクラス
     */
    public class ImageEffect : MonoBehaviour
    {
        private Animator            animator;
        //アニメーションの詳細な情報を取得するための宣言
        private AnimatorStateInfo   animInfo => animator.GetCurrentAnimatorStateInfo(0);

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            if (AnimationEndChack())
            {
                //終わっていたら削除
                Destroy(gameObject);
            }
        }
        //アニメーションが終わってるかを判定
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
