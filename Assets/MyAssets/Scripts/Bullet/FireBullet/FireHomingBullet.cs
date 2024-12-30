using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �^�[�Q�b�g�Ɍ������ăz�[�~���O��"����"���s�����������s����N���X
    /// </summary>
    [System.Serializable]
    public class FireHomingBullet : IFireBullet
    {
        private Transform   transform;

        private Timer       timer = new Timer();

        //�e�̃f�[�^
        private OffScreenObject bullet;

        private SEManager   seManager;
        //���ˊԊu�̐��l
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

        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)EnemyBulletType.Homing];
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
            HomingBullet homingBullet = g.GetComponent<HomingBullet>();
            if (homingBullet != null)
            {
                homingBullet.SetShooterType(ShopterType.Enemy);
                homingBullet.SetExeclude(transform.gameObject.layer);
                homingBullet.SetHomingTarget(target);
            }
            seManager.Play(1);
            timer.Start(fireCoolDownCount);
        }
    }
}
