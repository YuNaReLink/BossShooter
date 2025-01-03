using UnityEngine;

namespace CreateScript
{
    //弾の撃ち主を決めるためのenum
    public enum ShopterType
    {
        Player,
        Enemy
    }

    public enum BulletType
    {
        Null = -1,
        Straight,
        LockOn,
        Random,
        Homing,
        Bomb
    }
    /// <summary>
    /// ゲームに登場する弾すべてが継承してるベースのクラス
    /// 全弾に共通する処理、変数を持っている
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class BaseBullet : MonoBehaviour
    {
        [SerializeField]
        protected float                 bulletSpeed;

        [SerializeField]
        protected ImageEffect           effect;

        [SerializeField]
        private int power = 1;
        public int Power => power;

        protected new Rigidbody2D       rigidbody2D;

        protected BulletImage           bulletImage;

        protected ShopterType           shopterType;
        public ShopterType              ShopterType => shopterType;

        protected virtual BulletType    BulletType => BulletType.Null;

        protected SEManager             seManager;

        public void SetShooterType(ShopterType s)
        {
            shopterType = s;
        }

        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            bulletImage = GetComponentInChildren<BulletImage>();
            seManager = GetComponent<SEManager>();
        }

        public void SetExeclude(int layer)
        {
            gameObject.layer = layer;
        }
        /// <summary>
        /// 弾の当たり判定
        /// </summary>
        /// <param name="collision"></param>
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
            if(ShopterType == ShopterType.Player)
            {
                AddScore();
            }
            Erase(collision.ClosestPoint(transform.position));
        }
        //弾を消す処理
        protected virtual void Erase(Vector2 pos)
        {
            Destroy(gameObject);
            Instantiate(effect.gameObject, pos, Quaternion.identity);
            seManager.Play();
        }
        //スコアを加算
        //弾のタイプによって値が変化
        public void AddScore()
        {
            ScoreSystem.Instance.AddScore(BulletType);
        }
    }

}
