using UnityEngine;

namespace CreateScript
{
    /*
     * 敵の弾を全て破壊するボム本体のクラス
     */
    public class AllDestroyBomb : BaseBullet
    {
        private Vector2                 direction = Vector2.zero;

        private Timer                   explosionTimer = new Timer();
        //爆発するまでのカウント
        [SerializeField]
        private float                   explosionCount;

        public override BulletType   BulletType => BulletType.Bomb;
        private void Start()
        {
            rigidbody2D.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);

            explosionTimer.Start(explosionCount);
            explosionTimer.OnEnd += Explosion;
        }

        private void Update()
        {
            explosionTimer.Update(Time.deltaTime);
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }

        private void Explosion()
        {
            Erase(transform.position);
        }
        //爆発した時にゲームに存在する敵の弾をすべて削除する処理
        protected override void Erase(Vector2 pos)
        {
            GameController.Instance.DecreaseBombCount();
            BaseBullet[] baseBullets = FindObjectsOfType<BaseBullet>();
            foreach (BaseBullet bullet in baseBullets)
            {
                if (bullet.ShooterType == ShopterType.Enemy)
                {
                    //消した時に弾別にスコアを加算
                    ScoreSystem.Instance.AddScore(bullet.BulletType);
                    //エフェクト処理
                    effectManager.Create(bullet.transform.position, transform.localScale * effectScaleRatio);
                    Destroy(bullet.gameObject);
                }
            }
            base.Erase(pos);
        }
    }
}
