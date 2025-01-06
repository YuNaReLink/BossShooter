using UnityEngine;

namespace CreateScript
{
    /*
     * ���˒e��"����"���鏈�����s���N���X
     */
    [System.Serializable]
    public class FireRandomBullet : IFireBullet
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
        private float spreadAngle = 60.0f;


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
            bullet = launch.BulletData[(int)EnemyBulletType.Random];
            seHandler = launch.SEHandler;
        }
        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }
        //���ˏ���
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            // �����_���Ȋp�x�𐶐�
            float randomAngle = Random.Range(-spreadAngle, spreadAngle);

            // ���ˈʒu�̉�]���v�Z
            Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);

            // �e�𐶐�
            GameObject b = GameObject.Instantiate(bullet.gameObject, transform.position, transform.rotation * rotation);

            StraightBullet straightBullet = b.GetComponent<StraightBullet>();
            if (straightBullet != null)
            {
                //�e���˂ɕK�v�ȏ������s��
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Enemy);
                straightBullet.SetDirection(rotation * Vector2.left);
            }
            seHandler.Play((int)ShotSETag.Shot2);
            timer.Start(fireCoolDownCount);
        }
    }
}
