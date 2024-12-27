using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ゲーム中と結果画面で使用するスコアの管理を行うクラス
    /// 1つしか存在しないのと複数のシーンで使用するため
    /// グローバルのオブジェクトにアタッチ
    /// </summary>
    public class ScoreSystem : MonoBehaviour
    {
        private static ScoreSystem  instance;
        public static ScoreSystem   Instance => instance;

        [SerializeField]
        private int                 currentCount;
        public int                  CurrentCount => currentCount;

        private bool                changeAttack;
        public bool                 ChangeAttack => changeAttack;

        [SerializeField]
        private int                 scoreLine;

        [SerializeField]
        private int                 addScoreLine;

        //敵の弾を破壊した時に取得できるスコアの数値
        [SerializeField]
        private int                 smallScore;
        [SerializeField]
        private int                 middleScore;
        [SerializeField]
        private int                 bigScore;
        public void NoActivateChangeAttack()
        {
            changeAttack = false;
        }

        public void ResetScore()
        {
            currentCount = 0;
            scoreLine = 100;
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }

        private void Start()
        {
            scoreLine = addScoreLine;
        }

        public void AddScore(BulletType type)
        {
            int count = 0;
            switch (type)
            {
                case BulletType.Random:
                case BulletType.Straight:
                    count = smallScore;
                    break;
                case BulletType.LockOn:
                    count = middleScore;
                    break;
                case BulletType.Homing:
                    count = bigScore;
                    break;
            }
            currentCount += count;
            CurrentScoreCheck();
        }

        private void CurrentScoreCheck()
        {
            if (changeAttack) { return; }
            if(currentCount >= scoreLine)
            {
                changeAttack = true;
                scoreLine += addScoreLine;
            }
        }
    }

}
