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
    /// <summary>
    /// 敵の発射口のクラス
    /// 弾をタイプ別に発射する
    /// </summary>
    public class Launch : MonoBehaviour, IBaseLaunch
    {
        [SerializeField]
        private bool launchOff;

        [SerializeField]
        private IFireBullet[]       fireBullets;

        [SerializeField]
        private FireLockOnBullet    fireLockOnBullet;

        [SerializeField]
        private FireRandomBullet    fireRandomBullet;

        [SerializeField]
        private FireHomingBullet    fireHomingBullet;

        [SerializeField]
        private EnemyBulletType     bulletType;

        [SerializeField]
        private BulletData          bulletData;
        public BulletData           BulletData => bulletData;

        private SEManager           seManager;
        public SEManager            SEManager => seManager;

        public GameObject           GameObject => gameObject;

        public void SetBulleyType(EnemyBulletType type)
        {
            bulletType = type;
        }

        private void Awake()
        {

            seManager = GetComponent<SEManager>();

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
            if (GameController.Instance.IsGameStop) { return; }

            FireBulletsUpdate();
        }

        private void FireBulletsUpdate()
        {
            if (PlayerController.Player == null) { return; }
            fireBullets[(int)bulletType].Fire(PlayerController.Player.transform);
        }
    }
}
