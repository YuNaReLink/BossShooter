using UnityEngine;

namespace CreateScript
{
    /*
     * ターゲットに向かって弾を発射する処理を実行するクラス
     */
    [System.Serializable ]
    public class FireLockOnBullet : IFireBullet
    {
        private Transform       transform;

        private Timer           timer = new Timer();

        //弾のデータ
        private OffScreenObject bullet;

        private SEHandler       seHandler;
        //発射間隔の数値
        [SerializeField]
        private float           fireCoolDownCount = 0.1f;

        public float            MinFireCount => 0.25f;

        [SerializeField]
        private Vector2         direction = Vector2.zero;


        //発射間隔を減らす関数
        public void DecreaseFireCountCoolDown(float count)
        {
            fireCoolDownCount -= count;
            if (fireCoolDownCount <= MinFireCount)
            {
                fireCoolDownCount = MinFireCount;
            }
        }

        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)EnemyBulletType.LockOn];
            seHandler = launch.SEHandler;
        }
        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }
        //弾発射の関数
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            LockOnBullet lockOnBullet = g.GetComponent<LockOnBullet>();
            if (lockOnBullet != null)
            {
                //発射に必要な処理を行う
                lockOnBullet.SetShooterType(ShopterType.Enemy);
                lockOnBullet.SetExeclude(transform.gameObject.layer);
                lockOnBullet.SetPlayerTransform(target);
                lockOnBullet.SetDirection(direction);
            }
            seHandler.Play((int)ShotSETag.Shot2);
            timer.Start(fireCoolDownCount);
        }
    }
}
