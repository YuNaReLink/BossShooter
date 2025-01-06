using UnityEngine;

namespace CreateScript
{
    //プレイヤーの弾のリストの要素数に使うタグ
    public enum PlayerBulletType
    {
        Straight,
        Bomb
    }
    /*
     * プレイヤーの発射口のクラス
     */
    public class PlayerLaunch : MonoBehaviour,IBaseLaunch
    {
        //発射クラスをまとめて行うインタフェース
        [SerializeField]
        private IFireBullet[]       fireBullets;
        //下記はプレイヤーで発射できる弾の発射クラス
        [SerializeField]
        private FireStraightBullet  fireStraightBullet;

        [SerializeField]
        private FireBomb            fireBomb;
        //弾の種類を決めるタグ
        [SerializeField]
        private PlayerBulletType    bulletType;
        //プレイヤー入力
        private PlayerInput         input;
        //弾のデータをまとめて持っているもの
        [SerializeField]
        private BulletLedger          bulletData;
        public BulletLedger           BulletData => bulletData;
        //SEのデータを持っていて、再生を行うクラス
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
        //弾とボムの発射を行う
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
        //発射間隔を変更できるか調べる
        private void ChangeBulletCoolTimeByCurrentScore()
        {
            if (!ScoreSystem.Instance.IsScoreLine()) {  return; }
            Change();
        }
        //発射間隔を変更する処理
        private void Change()
        {
            fireBullets[(int)bulletType].DecreaseFireCountCoolDown(0.05f);
        }
    }
}
