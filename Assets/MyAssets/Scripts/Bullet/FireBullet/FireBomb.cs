using UnityEngine;

namespace CreateScript
{
    /*
     * �G�̒e�����ׂď����{����"����"���s���N���X
     */
    [System.Serializable]
    public class FireBomb : IFireBullet
    {
        private Transform       transform;

        private Timer           timer = new Timer();
        //�e�̃f�[�^
        private OffScreenObject bullet;

        private SEHandler       seHandler;
        //���ˊԊu�̃J�E���g
        [SerializeField]
        private float           fireCoolDownCount = 0.1f;
        public float            MinFireCount => 0.25f;

        [SerializeField]
        private Vector2         direction = Vector2.zero;


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
            bullet = launch.BulletData[(int)PlayerBulletType.Bomb];
            seHandler = launch.SEHandler;
        }

        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }
        //�{���𔭎˂��鏈��
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            AllDestroyBomb bomb = g.GetComponent<AllDestroyBomb>();
            if (bomb != null)
            {
                //���˂ɕK�v�ȏ������s��
                bomb.SetExeclude(transform.gameObject.layer);
                bomb.SetShooterType(ShopterType.Player);
                bomb.SetDirection(direction);
            }
            seHandler.Play((int)ShotSETag.Bomb);
            timer.Start(fireCoolDownCount);
        }
    }
}
