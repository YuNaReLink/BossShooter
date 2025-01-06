using UnityEngine;

namespace CreateScript
{
    /*
     * 弾の撃ち主を決めるためのenum
     */
    public enum ShopterType
    {
        Player,
        Enemy
    }
    /*
     * 弾の種類を決めるタグ
     */
    public enum BulletType
    {
        Null = -1,
        Straight,
        LockOn,
        Random,
        Homing,
        Bomb
    }
    /*
     * ゲームに登場する弾すべてが継承してるベースのクラス
     * 全弾に共通する処理、変数を持っている
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(EffectHandler))]
    public class BaseBullet : MonoBehaviour
    {
        //弾のスピード
        [SerializeField]
        protected float                 bulletSpeed;
        //エフェクト処理
        [SerializeField]
        protected EffectHandler         effectManager;
        //エフェクトのサイズの比率
        [SerializeField]
        protected float                 effectScaleRatio = 5f;
        
        protected new Rigidbody2D       rigidbody2D;
        //弾のイメージクラス
        protected BulletImage           bulletImage;
        //誰が撃ったのかを差別化するための宣言
        protected ShopterType           shooterType;
        public ShopterType              ShooterType => shooterType;
        //弾のタイプを記録する変数
        protected virtual BulletType    BulletType => BulletType.Null;
        //SE処理
        protected SEHandler             seHandler;

        public void SetShooterType(ShopterType s)
        {
            shooterType = s;
        }

        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            bulletImage = GetComponentInChildren<BulletImage>();
            effectManager = GetComponent<EffectHandler>();
            seHandler = GetComponent<SEHandler>();
        }

        public void SetExeclude(int layer)
        {
            gameObject.layer = layer;
        }
        // 弾の当たり判定
        protected void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterHit(collision);
            BulletHit(collision);
        }
        //弾がプレイヤーかボスに当たった時
        private void CharacterHit(Collider2D collision)
        {
            HP hp = collision.GetComponent<HP>();
            if (hp == null || collision.transform.gameObject.layer == gameObject.layer) { return; }
            Erase(collision.ClosestPoint(transform.position));
        }
        //弾が別の弾に当たった時
        private void BulletHit(Collider2D collision)
        {
            OffScreenObject bullet = collision.GetComponent<OffScreenObject>();
            if (bullet == null || collision.transform.gameObject.layer == gameObject.layer) { return; }
            if(ShooterType == ShopterType.Player)
            {
                AddScore();
            }
            Erase(collision.ClosestPoint(transform.position));
        }
        //弾を消す処理
        protected virtual void Erase(Vector2 pos)
        {
            Destroy(gameObject);
            effectManager.Create(pos, transform.localScale * effectScaleRatio, (int)EffectTag.Hit);
            seHandler.Play();
        }
        //スコアを加算
        //弾のタイプによって値が変化
        public void AddScore()
        {
            ScoreSystem.Instance.AddScore(BulletType);
        }
    }

}
