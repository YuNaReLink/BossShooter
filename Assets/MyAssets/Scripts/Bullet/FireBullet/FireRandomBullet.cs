using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ���˒e��"����"���鏈�����s���N���X
    /// </summary>
    [System.Serializable]
    public class FireRandomBullet : IFireBullet
    {
        private Transform   transform;

        private Timer       timer = new Timer();

        private BulletData  bulletData;

        private SEManager   seManager;

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
            // �����_���Ȋp�x�𐶐�
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);

            // ���ˈʒu�̉�]���v�Z
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            // �e�𐶐�
            GameObject bullet = GameObject.Instantiate(bulletData[(int)EnemyBulletType.Random].gameObject, transform.position, transform.rotation * rotation);

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
