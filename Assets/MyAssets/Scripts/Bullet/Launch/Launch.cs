using UnityEngine;

namespace CreateScript
{
    public enum EnemyBulletType
    {
        LockOn,
        Random,
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

            FireBulletsUpdate();
        }

        private void FireBulletsUpdate()
        {
            if (targetTransform == null) { return; }
            fireBullets[(int)bulletType].Fire(targetTransform);
        }
    }
}
