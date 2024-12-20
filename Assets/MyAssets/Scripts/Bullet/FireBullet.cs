using UnityEngine;

namespace CreateScript
{
    public class FireBullet : MonoBehaviour
    {
        private Timer timer = new Timer();

        [SerializeField]
        private BulletData bulletData;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;

        [SerializeField]
        private Vector2 direction = Vector2.zero;

        [SerializeField]
        private float spreadAngle = 60.0f;

        private void Update()
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire()
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = Instantiate(bulletData.Bullets[(int)BulletType.Straight].gameObject, transform.position,Quaternion.identity);
            StraightBullet straightBullet = g.GetComponent<StraightBullet>();
            if(straightBullet != null)
            {
                straightBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
        }

        public void LockOnFire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = Instantiate(bulletData.Bullets[(int)BulletType.LockOn].gameObject, transform.position, Quaternion.identity);
            LockOnBullet lockOnBullet = g.GetComponent<LockOnBullet>();
            if (lockOnBullet != null)
            {
                lockOnBullet.SetPlayerTransform(target);
                lockOnBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
        }

        public void RandomShotFire()
        {
            if (!timer.IsEnd()) { return; }
            // ÉâÉìÉ_ÉÄÇ»äpìxÇê∂ê¨
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);

            // î≠éÀà íuÇÃâÒì]ÇåvéZ
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            // íeÇê∂ê¨
            GameObject bullet = Instantiate(bulletData.Bullets[(int)BulletType.Random].gameObject, transform.position, transform.rotation * rotation);

            StraightBullet straightBullet = bullet.GetComponent<StraightBullet>();
            if (straightBullet != null)
            {
                straightBullet.SetDirection(rotation * Vector2.left);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
