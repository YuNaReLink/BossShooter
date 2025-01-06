using UnityEngine;

namespace CreateScript
{
    //敵が発射する弾を識別するためのenum
    public enum EnemyBulletType
    {
        LockOn,
        Random,
        Homing
    }
    /*
     * 敵の発射口のクラス
     * 弾をタイプ別に発射する
     */
    public class Launch : MonoBehaviour, IBaseLaunch
    {
        //発射を止めるフラグ
        [SerializeField]
        private bool                launchOff;
        //複数ある発射クラスをまとめて処理するもの
        [SerializeField]
        private IFireBullet[]       fireBullets;
        //下記は各別々の弾を発射するクラス
        [SerializeField]
        private FireLockOnBullet    fireLockOnBullet;

        [SerializeField]
        private FireRandomBullet    fireRandomBullet;

        [SerializeField]
        private FireHomingBullet    fireHomingBullet;
        //弾の種類を決めるためのタグ
        [SerializeField]
        private EnemyBulletType     bulletType;
        //弾のデータをまとめて取得してるもの
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
        //ターゲットがいるなら発射を行う関数
        private void FireBulletsUpdate()
        {
            if (PlayerController.Player == null) { return; }
            fireBullets[(int)bulletType].Fire(PlayerController.Player.transform);
        }
    }
}
