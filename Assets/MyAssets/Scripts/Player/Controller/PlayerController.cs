using UnityEngine;

namespace CreateScript
{
    public class PlayerController : MonoBehaviour,PlayerSetup
    {
        private static PlayerController player;
        public static PlayerController Player => player;
        public GameObject GameObject => gameObject;

        private PlayerInput input;
        public PlayerInput Input => input;

        [SerializeField]
        private PlayerMovement movement;

        private Launch launch;

        private HP hp;
        private void Awake()
        {
            player = this;

            input = GetComponent<PlayerInput>();
            launch = GetComponentInChildren<Launch>();
            hp = GetComponent<HP>();
        }

        private void Start()
        {
            movement.Setup(this);
        }
    
        private void Update()
        {
            if (GameController.Instance.IsGameStop) { return; }
            movement.Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }

        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null||bullet.ShopterType == ShopterType.Player) { return; }
            hp.DecreaseHP(1);
            if (hp.Death())
            {
                Death();
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
