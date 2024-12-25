using UnityEngine;

namespace CreateScript
{
    [System.Serializable ]
    public class FireLockOnBullet : IFireBullet
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
        private Vector2 direction = Vector2.zero;

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
            GameObject g = GameObject.Instantiate(bulletData.Bullets[(int)EnemyBulletType.LockOn].gameObject, transform.position, Quaternion.identity);
            LockOnBullet lockOnBullet = g.GetComponent<LockOnBullet>();
            if (lockOnBullet != null)
            {
                lockOnBullet.SetShooterType(ShopterType.Enemy);
                lockOnBullet.SetExeclude(transform.gameObject.layer);
                lockOnBullet.SetPlayerTransform(target);
                lockOnBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
