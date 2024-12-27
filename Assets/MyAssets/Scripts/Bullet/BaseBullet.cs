using UnityEngine;

namespace CreateScript
{
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
        Homing
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

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterHit(collision);
            Bullethit(collision);
        }

        private void CharacterHit(Collider2D collision)
        {
            HP hp = collision.GetComponent<HP>();
            if (hp == null || collision.transform.gameObject.layer == gameObject.layer) { return; }
            Erase(collision.ClosestPoint(transform.position));
        }

        private void Bullethit(Collider2D collision)
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet == null || collision.transform.gameObject.layer == gameObject.layer) { return; }
            Erase(collision.ClosestPoint(transform.position));
        }
        protected virtual void Erase(Vector2 pos)
        {
            AddScore();
            Destroy(gameObject);
            Instantiate(effect.gameObject, pos, Quaternion.identity);
            seManager.Play();
        }

        public void AddScore()
        {
            if (ShopterType == ShopterType.Enemy)
            {
                ScoreSystem.Instance.AddScore(BulletType);
            }
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            CharacterHit(collision.collider);
        }

    }

}
