using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 乱射弾を"発射"する処理を行うクラス
    /// </summary>
    [System.Serializable]
    public class FireRandomBullet : IFireBullet
    {
        private Transform   transform;

        private Timer       timer = new Timer();

        //弾のデータ
        private OffScreenObject bullet;

        private SEManager   seManager;
        //発射間隔の数値
        [SerializeField]
        private float       fireCoolDownCount = 0.1f;
        public float        MinFireCount => 0.25f;
        public void DecreaseFireCountCoolDown(float count)
        {
            fireCoolDownCount -= count;
            if (fireCoolDownCount <= MinFireCount)
            {
                fireCoolDownCount = MinFireCount;
            }
        }

        [SerializeField]
        private float spreadAngle = 60.0f;
        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)EnemyBulletType.Random];
            seManager = launch.SEManager;
        }
        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            // ランダムな角度を生成
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);

            // 発射位置の回転を計算
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            // 弾を生成
            GameObject b = GameObject.Instantiate(bullet.gameObject, transform.position, transform.rotation * rotation);

            StraightBullet straightBullet = b.GetComponent<StraightBullet>();
            if (straightBullet != null)
            {
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Enemy);
                straightBullet.SetDirection(rotation * Vector2.left);
            }
            seManager.Play(1);
            timer.Start(fireCoolDownCount);
        }
    }
}
