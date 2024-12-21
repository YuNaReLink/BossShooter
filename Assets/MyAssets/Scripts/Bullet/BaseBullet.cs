using UnityEngine;

namespace CreateScript
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class BaseBullet : MonoBehaviour
    {
        [SerializeField]
        protected float bulletSpeed;

        [SerializeField]
        private ImageEffect effect;

        protected new Rigidbody2D rigidbody2D;

        protected BulletImage bulletImage;

        protected Transform shooterTransform;
        public Transform ShooterTransform => shooterTransform;

        public void SetShooterTransform(Transform t)
        {
            shooterTransform = t;
        }

        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            bulletImage = GetComponentInChildren<BulletImage>();
        }

        public void SetExeclude(int layer)
        {
            gameObject.layer = layer;
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            BodyHit(collision);
            Bullethit(collision);
        }

        private void BodyHit(Collider2D collision)
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
        private void Erase(Vector2 pos)
        {
            Destroy(gameObject);
            Instantiate(effect.gameObject, pos, Quaternion.identity);
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            BodyHit(collision.collider);
        }

    }

}
