using UnityEngine;

namespace CreateScript
{
    /*
     * —ŽË’e‚ð"”­ŽË"‚·‚éˆ—‚ðs‚¤ƒNƒ‰ƒX
     */
    [System.Serializable]
    public class FireRandomBullet : IFireBullet
    {
        private Transform   transform;

        private Timer       timer = new Timer();

        //’e‚Ìƒf[ƒ^
        private OffScreenObject bullet;

        private SEManager   seManager;
        //”­ŽËŠÔŠu‚Ì”’l
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
        private float spreadAngle = 60.0f;
        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)EnemyBulletType.Random];
            seManager = launch.SEManager;
        }
        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            // ƒ‰ƒ“ƒ_ƒ€‚ÈŠp“x‚ð¶¬
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);

            // ”­ŽËˆÊ’u‚Ì‰ñ“]‚ðŒvŽZ
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            // ’e‚ð¶¬
            GameObject b = GameObject.Instantiate(bullet.gameObject, transform.position, transform.rotation * rotation);

            StraightBullet straightBullet = b.GetComponent<StraightBullet>();
            if (straightBullet != null)
            {
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Enemy);
                straightBullet.SetDirection(rotation * Vector2.left);
            }
            seManager.Play(1);
            timer.Start(fireCoolDownCount);
        }
    }
}
