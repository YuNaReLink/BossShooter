using UnityEngine;

namespace CreateScript
{
    [System.Serializable]
    public class FireRandomBullet : IFireBullet
    {
        private Transform transform;

        private Timer timer = new Timer();

        [SerializeField]
        private BulletData bulletData;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;

        [SerializeField]
        private float spreadAngle = 60.0f;
        public void Setup(Transform t)
        {
            transform = t;
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
            GameObject bullet = GameObject.Instantiate(bulletData.Bullets[2].gameObject, transform.position, transform.rotation * rotation);

            StraightBullet straightBullet = bullet.GetComponent<StraightBullet>();
            if (straightBullet != null)
            {
                straightBullet.SetShooterTransform(transform);
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetDirection(rotation * Vector2.left);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
