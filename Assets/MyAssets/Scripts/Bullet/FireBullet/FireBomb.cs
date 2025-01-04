using UnityEngine;

namespace CreateScript
{
    /*
     * 敵の弾をすべて消すボムの"発射"を行うクラス
     */
    [System.Serializable]
    public class FireBomb : IFireBullet
    {
        private Transform   transform;

        private Timer       timer = new Timer();
        //弾のデータ
        private OffScreenObject bullet;

        private SEManager   seManager;
        //発射間隔のカウント
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
            bullet = launch.BulletData[(int)PlayerBulletType.Bomb];
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
            AllDestroyBomb bomb = g.GetComponent<AllDestroyBomb>();
            if (bomb != null)
            {
                bomb.SetExeclude(transform.gameObject.layer);
                bomb.SetShooterType(ShopterType.Player);
                bomb.SetDirection(direction);
            }
            seManager.Play(2);
            timer.Start(fireCoolDownCount);
        }
    }
}
