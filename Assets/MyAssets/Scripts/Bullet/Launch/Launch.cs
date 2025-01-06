using UnityEngine;

namespace CreateScript
{
    //�G�����˂���e�����ʂ��邽�߂�enum
    public enum EnemyBulletType
    {
        LockOn,
        Random,
        Homing
    }
    /*
     * �G�̔��ˌ��̃N���X
     * �e���^�C�v�ʂɔ��˂���
     */
    public class Launch : MonoBehaviour, IBaseLaunch
    {
        //���˂��~�߂�t���O
        [SerializeField]
        private bool                launchOff;
        //�������锭�˃N���X���܂Ƃ߂ď����������
        [SerializeField]
        private IFireBullet[]       fireBullets;
        //���L�͊e�ʁX�̒e�𔭎˂���N���X
        [SerializeField]
        private FireLockOnBullet    fireLockOnBullet;

        [SerializeField]
        private FireRandomBullet    fireRandomBullet;

        [SerializeField]
        private FireHomingBullet    fireHomingBullet;
        //�e�̎�ނ����߂邽�߂̃^�O
        [SerializeField]
        private EnemyBulletType     bulletType;
        //�e�̃f�[�^���܂Ƃ߂Ď擾���Ă����
        [SerializeField]
        private BulletLedger          bulletData;
        public BulletLedger           BulletData => bulletData;

        private SEHandler           seHandler;
        public SEHandler            SEHandler => seHandler;

        public GameObject           GameObject => gameObject;

        public void SetBulleyType(EnemyBulletType type)
        {
            bulletType = type;
        }

        private void Awake()
        {

            seHandler = GetComponent<SEHandler>();

            IFireBullet[] bullets = new IFireBullet[]{
                fireLockOnBullet,
                fireRandomBullet,
                fireHomingBullet
            };
            fireBullets = bullets;
            foreach (IFireBullet fireBullet in fireBullets)
            {
                fireBullet.Setup(this);
            }
        }


        private void Update()
        {
            if (launchOff) { return; }
            fireBullets[(int)bulletType].DoUpdate(Time.deltaTime);
            if (GlobalManager.Instance.IsGameStop) { return; }

            FireBulletsUpdate();
        }
        //�^�[�Q�b�g������Ȃ甭�˂��s���֐�
        private void FireBulletsUpdate()
        {
            if (PlayerController.Player == null) { return; }
            fireBullets[(int)bulletType].Fire(PlayerController.Player.transform);
        }
    }
}
