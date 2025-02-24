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
        //現在取得中のスコア
        [SerializeField]
        private int                 currentCount;
        public int                  CurrentCount => currentCount;
        //プレイヤーの攻撃間隔を上げるかどうかラインの数値
        [SerializeField]
        private int                 currentScoreLine;
        //ラインよりもスコアが増加したらaddScoreLineでLineを増加
        [SerializeField]
        private int                 addScoreLine;

        //敵の弾を破壊した時に取得できるスコアの数値
        [SerializeField]
        private int                 smallScore;
        [SerializeField]
        private int                 middleScore;
        [SerializeField]
        private int                 bigScore;

        public void ResetScore()
        {
            currentCount = 0;
            currentScoreLine = 100;
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
            currentScoreLine = addScoreLine;
        }
        //スコアを弾別に取得してる
        public void AddScore(BulletType type)
        {
            int count = 0;
            switch (type)
            {
                case BulletType.LockOn:
                case BulletType.Straight:
                    count = smallScore;
                    break;
                case BulletType.Random:
                    count = middleScore;
                    break;
                case BulletType.Homing:
                    count = bigScore;
                    break;
            }
            currentCount += count;
        }
        //取得スコアが上限に到達してるか確認
        public bool IsScoreLine()
        {
            if(currentCount >= currentScoreLine)
            {
                currentScoreLine += addScoreLine;
                return true;
            }
            return false;
        }
    }

}
