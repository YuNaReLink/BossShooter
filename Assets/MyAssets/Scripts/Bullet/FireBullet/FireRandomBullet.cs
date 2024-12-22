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
            // ÉâÉìÉ_ÉÄÇ»äpìxÇê∂ê¨
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);

            // î≠éÀà íuÇÃâÒì]ÇåvéZ
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            // íeÇê∂ê¨
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
