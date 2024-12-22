using UnityEngine;

namespace CreateScript
{
    //プレイヤーの弾のリストの要素数に使うタグ
    public enum PlayerBulletType
    {
        Straight,
        Bomb
    }
    public class PlayerLaunch : MonoBehaviour
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
                fireBullet.Setup(transform.parent);
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
    }
}
