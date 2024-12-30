using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 指定した方向に真っすぐ飛ぶ弾を"発射"する処理を行うクラス
    /// </summary>
    [System.Serializable]
    public class FireStraightBullet : IFireBullet
    {
        private Transform   transform;

        private Timer       timer = new Timer();

        //弾のデータ
        private OffScreenObject bullet;

        private SEManager   seManager;
        //発射間隔の数値
        [SerializeField]
        private float       fireCoolDownCount = 0.1f;
        //弾発射間隔の最低間隔
        public float        MinFireCount => 0.25f;
        public void DecreaseFireCountCoolDown(float count)
        {
            fireCoolDownCount -= count;
            if(fireCoolDownCount <= MinFireCount)
            {
                fireCoolDownCount = MinFireCount;
            }
        }

        [SerializeField]
        private Vector2 direction = Vector2.zero;

        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)PlayerBulletType.Straight];
            seManager = launch.SEManager;
        }

        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position,Quaternion.identity);
            StraightBullet straightBullet = g.GetComponent<StraightBullet>();
            if(straightBullet != null)
            {
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Player);
                straightBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
            seManager.Play();
        }
    }
}
