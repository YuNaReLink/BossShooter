using UnityEngine;

namespace CreateScript
{
    /*
     * �^�[�Q�b�g�Ɍ������ăz�[�~���O��"����"���s�����������s����N���X
     */
    [System.Serializable]
    public class FireHomingBullet : IFireBullet
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
            bullet = launch.BulletData[(int)EnemyBulletType.Homing];
            seHandler = launch.SEHandler;
        }
        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }
        //�z�[�~���O���˂��s���֐�
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            HomingBullet homingBullet = g.GetComponent<HomingBullet>();
            if (homingBullet != null)
            {
                //���˂ɕK�v�ȏ������s��
                homingBullet.SetShooterType(ShopterType.Enemy);
                homingBullet.SetExeclude(transform.gameObject.layer);
                homingBullet.InitHomingSetting(target);
            }
            seHandler.Play((int)ShotSETag.Shot2);
            timer.Start(fireCoolDownCount);
        }
    }
}
