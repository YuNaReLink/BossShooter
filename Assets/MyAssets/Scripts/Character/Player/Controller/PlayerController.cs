using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// プレイヤー処理を管理するクラス
    /// 主にHP、移動、アニメーション、当たり判定を行う
    /// </summary>

    public class PlayerController : MonoBehaviour,PlayerSetup
    {
        [SerializeField]
        private PlayerMovement              movement;


        public GameObject                   GameObject => gameObject;
        
        private static PlayerController     player;
        public static PlayerController      Player => player;

        private PlayerInput                 input;
        public PlayerInput                  Input => input;

        private HP                          hp;

        private EffectManager               effectManager;

        private SEManager                   seManager;

        private Animator                    animator;


        private void Awake()
        {
            player = this;

            input = GetComponent<PlayerInput>();
            hp = GetComponent<HP>();
            effectManager = GetComponent<EffectManager>();
            seManager = GetComponent<SEManager>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
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

        private bool NoActiveDamageCheck(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            BossController boss = collision.GetComponent<BossController>();
            BossParts parts = collision.GetComponent<BossParts>();
            return  ((bullet != null && bullet.ShopterType != ShopterType.Player)||
                    boss != null || parts != null);
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
