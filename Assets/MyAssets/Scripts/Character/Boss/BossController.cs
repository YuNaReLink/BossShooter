using UnityEngine;


namespace CreateScript
{
    /*
     * �{�X�{�̂̊Ǘ��N���X
     */
    public class BossController : MonoBehaviour,BossSetup,BossDamager
    {
        //�I�u�W�F�N�g
        public GameObject           GameObject => gameObject;

        //HP����
        private HP                  hp;
        //�{�X��HP��UI�ŕ\�����邽�߂�public�֐�
        public HP                   HP => hp;
        //�G�t�F�N�g����
        private EffectHandler       effectManager;
        //SE����
        private SEHandler           seHandler;
        //�J���[�ύX����
        private ColorChanger        colorChanger;
        //�ړ�����
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
