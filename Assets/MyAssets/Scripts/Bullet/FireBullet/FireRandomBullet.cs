using UnityEngine;

namespace CreateScript
{
    [System.Serializable]
    public class FireRandomBullet : IFireBullet
    {
        private Transform transform;

        private Timer timer = new Timer();

        private BulletData bulletData;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;
        private float minCount = 0.2f;
        public void DecreaseCoolDownCount(float count)
        {
            fireCoolDownCount -= count;
            if (fireCoolDownCount <= minCount)
            {
                fireCoolDownCount = minCount;
            }
        }

        [SerializeField]
        private float spreadAngle = 60.0f;
        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bulletData = launch.BulletData;
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
            GameObject bullet = GameObject.Instantiate(bulletData.Bullets[(int)EnemyBulletType.Random].gameObject, transform.position, transform.rotation * rotation);

            StraightBullet straightBullet = bullet.GetComponent<StraightBullet>();
            if (straightBullet != null)
            {
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Enemy);
                straightBullet.SetDirection(rotation * Vector2.left);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
