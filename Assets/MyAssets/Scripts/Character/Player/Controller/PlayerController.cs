using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �v���C���[�������Ǘ�����N���X
    /// ���HP�A�ړ��A�A�j���[�V�����A�����蔻����s��
    /// </summary>

    public class PlayerController : MonoBehaviour,PlayerSetup
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
        private EffectManager               effectManager;
        //SE����
        private SEManager                   seManager;
        //�A�j���[�V��������
        private Animator                    animator;
        //�ړ�����
        [SerializeField]
        private PlayerMovement              movement;

        private void Awake()
        {
            player = this;

            input = GetComponent<PlayerInput>();
            hp = GetComponent<HP>();
            effectManager = GetComponent<EffectManager>();
            seManager = GetComponent<SEManager>();
            animator = GetComponent<Animator>();


            movement.Setup(this);
        }
    
        private void Update()
        {
            if (GameController.Instance.IsGameStop) { return; }
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
                seManager.Play();
                effectManager.Create(transform.position,transform.localScale);
                Death();
            }
        }
        //�����������̂��������ׂ�
        //�����ɓ�������̂Ȃ�_���[�W���N����
        private bool NoActiveDamageCheck(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            BossController boss = collision.GetComponent<BossController>();
            BossParts parts = collision.GetComponent<BossParts>();
            return  ((bullet != null && bullet.ShopterType != ShopterType.Player)||
                    boss != null || parts != null);
        }
        //���S����
        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
