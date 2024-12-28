using UnityEngine;

namespace CreateScript
{
    public enum EnemyBulletType
    {
        LockOn,
        Random,
        Homing
    }

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

        private Transform targetTransform;

        private void Awake()
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            targetTransform = player.transform;

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
