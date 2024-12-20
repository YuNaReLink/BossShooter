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

        private FireBullet fireBullet;

        [SerializeField]
        private bool lockOn = false;
        [SerializeField]
        private bool randomShot = false;
        [SerializeField]
        private bool homing = false;

        private void Awake()
        {
            movement.Setup(this);

            playerController = FindObjectOfType<PlayerController>();

            fireBullet = GetComponentInChildren<FireBullet>();
        }

        private void Start()
        {
            movement.DoStart();
        }


        private void Update()
        {
            movement.VerticalMove();


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

            }
        }
    }
}
