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
            // ƒ‰ƒ“ƒ_ƒ€‚ÈŠp“x‚ğ¶¬
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);

            // ”­ËˆÊ’u‚Ì‰ñ“]‚ğŒvZ
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            // ’e‚ğ¶¬
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
