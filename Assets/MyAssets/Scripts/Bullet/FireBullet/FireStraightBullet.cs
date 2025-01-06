using UnityEngine;

namespace CreateScript
{
    /*
     * �w�肵�������ɐ^��������Ԓe��"����"���鏈�����s���N���X
     */
    [System.Serializable]
    public class FireStraightBullet : IFireBullet
    {
        private Transform       transform;

        private Timer           timer = new Timer();

        //�e�̃f�[�^
        private OffScreenObject bullet;

        private SEHandler       seHandler;
        //���ˊԊu�̐��l
        [SerializeField]
        private float           fireCoolDownCount = 0.1f;
        //�e���ˊԊu�̍Œ�Ԋu
        public float            MinFireCount => 0.25f;
        [SerializeField]
        private Vector2         direction = Vector2.zero;


        //���ˊԊu�����炷����
        public void DecreaseFireCountCoolDown(float count)
        {
            fireCoolDownCount -= count;
            if(fireCoolDownCount <= MinFireCount)
            {
                fireCoolDownCount = MinFireCount;
            }
        }


        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)PlayerBulletType.Straight];
            seHandler = launch.SEHandler;
        }

        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }
        //�e���ˏ���
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position,Quaternion.identity);
            StraightBullet straightBullet = g.GetComponent<StraightBullet>();
            if(straightBullet != null)
            {
                //�e���˂ɕK�v�ȏ������s��
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Player);
                straightBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
            seHandler.Play();
        }
    }
}
