using UnityEngine;

namespace CreateScript
{
    [System.Serializable ]
    public class FireLockOnBullet : IFireBullet
    {
        private Transform transform;

        private Timer timer = new Timer();

        [SerializeField]
        private BulletData bulletData;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;

        [SerializeField]
        private Vector2 direction = Vector2.zero;

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
            GameObject g = GameObject.Instantiate(bulletData.Bullets[(int)1].gameObject, transform.position, Quaternion.identity);
            LockOnBullet lockOnBullet = g.GetComponent<LockOnBullet>();
            if (lockOnBullet != null)
            {
                lockOnBullet.SetShooterTransform(transform);
                lockOnBullet.SetExeclude(transform.gameObject.layer);
                lockOnBullet.SetPlayerTransform(target);
                lockOnBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
