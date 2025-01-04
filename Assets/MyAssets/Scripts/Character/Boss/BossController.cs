using UnityEngine;


namespace CreateScript
{
    /*
     * ボス本体の管理クラス
     */
    public class BossController : MonoBehaviour,BossSetup
    {
        //オブジェクト
        public GameObject           GameObject => gameObject;

        //HP処理
        private HP                  hp;
        public HP                   HP => hp;
        //エフェクト処理
        private EffectManager       effectManager;
        //SE処理
        private SEManager           seManager;
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
