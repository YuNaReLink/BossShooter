using UnityEngine;

namespace CreateScript
{
    /*
     * プレイヤー処理を管理するクラス
     * 主にHP、移動、アニメーション、当たり判定を行う
     */

    public class PlayerController : MonoBehaviour,PlayerSetup,PlayerDamager
    {
        //自分自身
        //復活した時に必要になるもの
        private static PlayerController     player;
        public static PlayerController      Player => player;
        //ゲームオブジェクト
        public GameObject                   GameObject => gameObject;
        //入力
        private PlayerInput                 input;
        public PlayerInput                  Input => input;
        //HP処理
        private HP                          hp;
        //エフェクト処理
        private EffectHandler               effectManager;
        //SE処理
        private SEHandler                   seHandler;
        //アニメーション処理
        private Animator                    animator;
        //移動処理
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
        //ダメージ処理
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
        //当たったものが何か調べる
        //条件に当たるものならダメージを起こす
        private bool NoActiveDamageCheck(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            BossDamager bossDamager = collision.GetComponent<BossDamager>();
            return  ((bullet != null && bullet.ShooterType != ShopterType.Player)||
                    bossDamager != null );
        }
        //死亡処理
        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
