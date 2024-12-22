using UnityEngine;

namespace CreateScript
{
    public enum EnemyBulletType
    {
        Random,
        LockOn,
        Homing
    }

    public class Launch : MonoBehaviour
    {
        [SerializeField]
        private IFireBullet[] fireBullets;

        [SerializeField]
        private FireLockOnBullet fireLockOnBullet;

        [SerializeField]
        private FireRandomBullet fireRandomBullet;

        [SerializeField]
        private FireHomingBullet fireHomingBullet;

        [SerializeField]
        private EnemyBulletType bulletType;

        public void SetBulleyType(EnemyBulletType type)
        {
            bulletType = type;
        }

        private Transform targetTransform;

        private void Awake()
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            targetTransform = player.transform;

            IFireBullet[] bullets = new IFireBullet[]{
                fireLockOnBullet,
                fireRandomBullet,
                fireHomingBullet
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

        }

        // Update is called once per frame
        void Update()
        {
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
