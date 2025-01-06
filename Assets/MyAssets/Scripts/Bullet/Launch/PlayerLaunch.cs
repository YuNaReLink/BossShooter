using UnityEngine;

namespace CreateScript
{
    //�v���C���[�̒e�̃��X�g�̗v�f���Ɏg���^�O
    public enum PlayerBulletType
    {
        Straight,
        Bomb
    }
    /*
     * �v���C���[�̔��ˌ��̃N���X
     */
    public class PlayerLaunch : MonoBehaviour,IBaseLaunch
    {
        //���˃N���X���܂Ƃ߂čs���C���^�t�F�[�X
        [SerializeField]
        private IFireBullet[]       fireBullets;
        //���L�̓v���C���[�Ŕ��˂ł���e�̔��˃N���X
        [SerializeField]
        private FireStraightBullet  fireStraightBullet;

        [SerializeField]
        private FireBomb            fireBomb;
        //�e�̎�ނ����߂�^�O
        [SerializeField]
        private PlayerBulletType    bulletType;
        //�v���C���[����
        private PlayerInput         input;
        //�e�̃f�[�^���܂Ƃ߂Ď����Ă������
        [SerializeField]
        private BulletLedger          bulletData;
        public BulletLedger           BulletData => bulletData;
        //SE�̃f�[�^�������Ă��āA�Đ����s���N���X
        private SEHandler           seHandler;
        public SEHandler            SEHandler => seHandler;

        public GameObject           GameObject => gameObject;

        private void Awake()
        {
            input = GetComponentInParent<PlayerInput>();

            seHandler = GetComponent<SEHandler>();

            IFireBullet[] bullets = new IFireBullet[]
            {
                fireStraightBullet,
                fireBomb
            };
            fireBullets = bullets;
            foreach (IFireBullet fireBullet in fireBullets)
            {
                fireBullet.Setup(this);
            }
        }


        private void Start()
        {
            bulletType = PlayerBulletType.Straight;
        }


        private void Update()
        {
            for(int i = 0; i < fireBullets.Length; i++)
            {
                fireBullets[i].DoUpdate(Time.deltaTime);
            }
            if (GlobalManager.Instance.IsGameStop) { return; }

            BulletFire();
            ChangeBulletCoolTimeByCurrentScore();
        }
        //�e�ƃ{���̔��˂��s��
        private void BulletFire()
        {
            if(input.Attack > 0)
            {
                fireBullets[(int)bulletType].Fire(null);
            }

            if(input.Bomb)
            {
                if(GameController.Instance.BombCount <=0) { return; }
                fireBullets[(int)PlayerBulletType.Bomb].Fire(null);
            }
        }
        //���ˊԊu��ύX�ł��邩���ׂ�
        private void ChangeBulletCoolTimeByCurrentScore()
        {
            if (!ScoreSystem.Instance.IsScoreLine()) {  return; }
            Change();
        }
        //���ˊԊu��ύX���鏈��
        private void Change()
        {
            fireBullets[(int)bulletType].DecreaseFireCountCoolDown(0.05f);
        }
    }
}
