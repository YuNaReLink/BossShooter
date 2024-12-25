using UnityEngine;

namespace CreateScript
{
    //プレイヤーの弾のリストの要素数に使うタグ
    public enum PlayerBulletType
    {
        Straight,
        Bomb
    }
    public class PlayerLaunch : MonoBehaviour,IBaseLaunch
    {
        [SerializeField]
        private IFireBullet[]       fireBullets;

        [SerializeField]
        private FireStraightBullet  fireStraightBullet;

        [SerializeField]
        private FireBomb            fireBomb;

        [SerializeField]
        private PlayerBulletType    bulletType;

        private PlayerInput         input;

        [SerializeField]
        private BulletData          bulletData;
        public BulletData           BulletData => bulletData;

        public GameObject           GameObject => gameObject;

        private void Awake()
        {
            input = GetComponentInParent<PlayerInput>();

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
            if (GameController.Instance.IsGameStop) { return; }

            BulletFire();
            ChangeBulletCoolTimeByCurrentScore();
        }

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

        private void ChangeBulletCoolTimeByCurrentScore()
        {
            if (!ScoreSystem.Instance.ChangeAttack) { return; }
            Change();
        }

        private void Change()
        {
            fireBullets[(int)bulletType].DecreaseCoolDownCount(0.05f);
            ScoreSystem.Instance.NoActivateChangeAttack();
        }
    }
}
