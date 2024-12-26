using UnityEngine;

namespace CreateScript
{
    [System.Serializable]
    public class FireRandomBullet : IFireBullet
    {
        private Transform transform;

        private Timer timer = new Timer();

        private BulletData bulletData;

        private SEManager seManager;

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
        private float spreadAngle = 60.0f;
        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bulletData = launch.BulletData;
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
            GameObject bullet = GameObject.Instantiate(bulletData.Bullets[(int)EnemyBulletType.Random].gameObject, transform.position, transform.rotation * rotation);

            StraightBullet straightBullet = bullet.GetComponent<StraightBullet>();
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
