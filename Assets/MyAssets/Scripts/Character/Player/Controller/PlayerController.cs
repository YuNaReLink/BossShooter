using UnityEngine;

namespace CreateScript
{
    /*
     * �v���C���[�������Ǘ�����N���X
     * ���HP�A�ړ��A�A�j���[�V�����A�����蔻����s��
     */

    public class PlayerController : MonoBehaviour,PlayerSetup,PlayerDamager
    {
        //�������g
        //�����������ɕK�v�ɂȂ����
        private static PlayerController     player;
        public static PlayerController      Player => player;
        //�Q�[���I�u�W�F�N�g
        public GameObject                   GameObject => gameObject;
        //����
        private PlayerInput                 input;
        public PlayerInput                  Input => input;
        //HP����
        private HP                          hp;
        //�G�t�F�N�g����
        private EffectHandler               effectManager;
        //SE����
        private SEHandler                   seHandler;
        //�A�j���[�V��������
        private Animator                    animator;
        //�ړ�����
        [SerializeField]
        private PlayerMovement              movement;

        private void OnEnable()
        {
            player = this;
        }

        private void OnDisable()
        {
            player = null;
        }

        private void Awake()
        {
            input = GetComponent<PlayerInput>();
            hp = GetComponent<HP>();
            effectManager = GetComponent<EffectHandler>();
            seHandler = GetComponent<SEHandler>();
            animator = GetComponent<Animator>();


            movement.Setup(this);
        }
    
        private void Update()
        {
            if (GlobalManager.Instance.IsGameStop) { return; }
            movement.Move();
            animator.SetFloat("Vertical",input.Move.y);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }
        //�_���[�W����
        private void Damage(Collider2D collision)
        {
            if (!NoActiveDamageCheck(collision)) { return; }
            hp.DecreaseHP();
            if (hp.Death())
            {
                seHandler.Play();
                effectManager.Create(transform.position,transform.localScale);
                Death();
            }
        }
        //�����������̂��������ׂ�
        //�����ɓ�������̂Ȃ�_���[�W���N����
        private bool NoActiveDamageCheck(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            BossDamager bossDamager = collision.GetComponent<BossDamager>();
            return  ((bullet != null && bullet.ShooterType != ShopterType.Player)||
                    bossDamager != null );
        }
        //���S����
        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
