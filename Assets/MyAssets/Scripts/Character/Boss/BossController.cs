using UnityEngine;


namespace CreateScript
{
    /// <summary>
    /// ボス本体の管理クラス
    /// </summary>
    public class BossController : MonoBehaviour,BossSetup
    {
        public GameObject           GameObject => gameObject;

        [SerializeField]
        private BossMovement        movement;
        public BossMovement         Movement => movement;

        private HP                  hp;
        public HP                   HP => hp;

        private EffectManager       effectManager;
        public EffectManager        EffectManager => effectManager;

        private SEManager           seManager;
        public SEManager            SEManager => seManager;

        private ColorChanger        colorChanger;

        private void Awake()
        {
            movement.Setup(this);

            hp = GetComponent<HP>();

            effectManager = GetComponent<EffectManager>();

            seManager = GetComponent<SEManager>();

            colorChanger = GetComponent<ColorChanger>();
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
            hp.DecreaseHP();
            colorChanger.ColorChangeStart();
            if (hp.Death())
            {
                seManager.Play();
                effectManager.Create(transform.position, transform.localScale);
                Death();
            }
        }

        private void Death()
        {
            FormChange formChange = GetComponentInParent<FormChange>();
            formChange.SetForm(1);
            ActivateGameClear result = GetComponent<ActivateGameClear>();
            result.GameClearResult();
            Destroy(gameObject);
        }
    }
}
