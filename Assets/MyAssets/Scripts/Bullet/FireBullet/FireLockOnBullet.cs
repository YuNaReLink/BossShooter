using UnityEngine;

namespace CreateScript
{
    /*
     * �^�[�Q�b�g�Ɍ������Ēe�𔭎˂��鏈�������s����N���X
     */
    [System.Serializable ]
    public class FireLockOnBullet : IFireBullet
    {
        private Transform       transform;

        private Timer           timer = new Timer();

        //�e�̃f�[�^
        private OffScreenObject bullet;

        private SEHandler       seHandler;
        //���ˊԊu�̐��l
        [SerializeField]
        private float           fireCoolDownCount = 0.1f;

        public float            MinFireCount => 0.25f;

        [SerializeField]
        private Vector2         direction = Vector2.zero;


        //���ˊԊu�����炷�֐�
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
        //�e���˂̊֐�
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            LockOnBullet lockOnBullet = g.GetComponent<LockOnBullet>();
            if (lockOnBullet != null)
            {
                //���˂ɕK�v�ȏ������s��
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
