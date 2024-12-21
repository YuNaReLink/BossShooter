using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    //プレイヤーの弾のリストの要素数に使うタグ
    public enum PlayerBulletType
    {
        Straight,
    }
    public class PlayerLaunch : MonoBehaviour
    {
        [SerializeField]
        private IFireBullet[] fireBullets;

        [SerializeField]
        private FireStraightBullet fireStraightBullet;

        [SerializeField]
        private PlayerBulletType bulletType;

        private PlayerInput input;

        private void Awake()
        {
            input = GetComponentInParent<PlayerInput>();

            IFireBullet[] bullets = new IFireBullet[]{
                fireStraightBullet,
            };
            fireBullets = bullets;
            foreach (IFireBullet fireBullet in fireBullets)
            {
                fireBullet.Setup(transform.parent);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            bulletType = PlayerBulletType.Straight;
        }

        // Update is called once per frame
        void Update()
        {
            fireBullets[(int)bulletType].DoUpdate(Time.deltaTime);

            BulletFire();
        }

        private void BulletFire()
        {
            if(input.Attack > 0)
            {
                fireBullets[(int)bulletType].Fire(null);
            }
        }
    }
}
