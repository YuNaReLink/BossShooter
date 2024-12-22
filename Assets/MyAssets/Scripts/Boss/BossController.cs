using UnityEngine;


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
            if (GameController.Instance.IsGameStop) { return; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }

        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null || bullet.ShopterType == ShopterType.Enemy) { return; }
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
