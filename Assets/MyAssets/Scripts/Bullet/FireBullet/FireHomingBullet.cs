using UnityEngine;

namespace CreateScript
{
    /*
     * ターゲットに向かってホーミングの"発射"を行う処理を実行するクラス
     */
    [System.Serializable]
    public class FireHomingBullet : IFireBullet
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
            bullet = launch.BulletData[(int)EnemyBulletType.Homing];
            seHandler = launch.SEHandler;
        }
        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }
        //ホーミング発射を行う関数
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            HomingBullet homingBullet = g.GetComponent<HomingBullet>();
            if (homingBullet != null)
            {
                //発射に必要な処理を行う
                homingBullet.SetShooterType(ShopterType.Enemy);
                homingBullet.SetExeclude(transform.gameObject.layer);
                homingBullet.InitHomingSetting(target);
            }
            seHandler.Play((int)ShotSETag.Shot2);
            timer.Start(fireCoolDownCount);
        }
    }
}
