using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ターゲットに向かって弾を発射する処理を実行するクラス
    /// </summary>
    [System.Serializable ]
    public class FireLockOnBullet : IFireBullet
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
        private Vector2 direction = Vector2.zero;

        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)EnemyBulletType.LockOn];
            seManager = launch.SEManager;
        }
        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            LockOnBullet lockOnBullet = g.GetComponent<LockOnBullet>();
            if (lockOnBullet != null)
            {
                lockOnBullet.SetShooterType(ShopterType.Enemy);
                lockOnBullet.SetExeclude(transform.gameObject.layer);
                lockOnBullet.SetPlayerTransform(target);
                lockOnBullet.SetDirection(direction);
            }
            seManager.Play(1);
            timer.Start(fireCoolDownCount);
        }
    }
}
