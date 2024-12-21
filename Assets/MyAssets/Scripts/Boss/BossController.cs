using UnityEngine;
using UnityEngine.UIElements;


namespace CreateScript
{
    public class BossController : MonoBehaviour,BossSetup
    {
        public GameObject GameObject => gameObject;

        [SerializeField]
        private EnemyMovement movement;

        [SerializeField]
        private PlayerController playerController;


        private Launch launch;

        [SerializeField]
        private BossParts[] bossParts;

        private HP hp;

        private void Awake()
        {
            movement.Setup(this);

            playerController = FindObjectOfType<PlayerController>();

            launch = GetComponentInChildren<Launch>();

            hp = GetComponent<HP>();

            BossParts[] parts = GetComponentsInChildren<BossParts>();
            if(parts.Length > 0)
            {
                bossParts = parts;
            }
        }

        private void Start()
        {
            movement.DoStart();
        }


        private void Update()
        {
            movement.VerticalMove();


            if(bossParts.Length <= 2)
            {
                //fireBullet.LockOnFire(playerController.transform);
            }
            else if(bossParts.Length <= 1)
            {
                //fireBullet.RandomShotFire();
            }
            else
            {
                //fireBullet.HomingFire(playerController.transform);
            }

            /*
            if (lockOn)
            {
                fireBullet.LockOnFire(playerController.transform);
            }
            if (randomShot)
            {
                fireBullet.RandomShotFire();
            }
            if (homing)
            {
                fireBullet.HomingFire(playerController.transform);
            }
             */
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }

        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null || bullet.ShooterTransform == transform) { return; }
            hp.DecreaseHP(1);
            if (hp.Death())
            {
                Death();
            }
        }

        private void Death()
        {
            FormChange formChange = GetComponentInParent<FormChange>();
            formChange.SetForm(1);
            Destroy(gameObject);
        }
    }
}
