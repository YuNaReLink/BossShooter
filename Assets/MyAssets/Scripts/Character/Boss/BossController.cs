using UnityEngine;


namespace CreateScript
{
    /*
     * ボス本体の管理クラス
     */
    public class BossController : MonoBehaviour,BossSetup,BossDamager
    {
        //オブジェクト
        public GameObject           GameObject => gameObject;

        //HP処理
        private HP                  hp;
        //ボスのHPをUIで表示するためのpublic関数
        public HP                   HP => hp;
        //エフェクト処理
        private EffectHandler       effectManager;
        //SE処理
        private SEHandler           seHandler;
        //カラー変更処理
        private ColorChanger        colorChanger;
        //移動処理
        [SerializeField]
        private BossMovement        movement;
        public BossMovement         Movement => movement;

        private void Awake()
        {
            movement.Setup(this);

            hp = GetComponent<HP>();

            effectManager = GetComponent<EffectHandler>();

            seHandler = GetComponent<SEHandler>();

            colorChanger = GetComponent<ColorChanger>();
        }

        private void Start()
        {
            movement.DoStart();
        }


        private void Update()
        {
            movement.VerticalMove();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }

        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null || bullet.ShooterType == ShopterType.Enemy) { return; }
            hp.DecreaseHP();
            colorChanger.ColorChangeStart();
            if (hp.Death())
            {
                seHandler.Play();
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
