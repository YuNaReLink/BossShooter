using UnityEngine;

namespace CreateScript
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class LockOnBullet : MonoBehaviour
    {
        [SerializeField]
        private float bulletSpeed = 10f;

        private new Rigidbody2D rigidbody2D;

        private Vector2 direction = Vector2.zero;
        public Vector2 Direction => direction;

        private BulletImage bulletImage;

        private Transform playerTransform;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            bulletImage = GetComponentInChildren<BulletImage>();
        }

        // Start is called before the first frame update
        void Start()
        {
            direction = playerTransform.position - transform.position;
            rigidbody2D.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);
        }

        public void SetPlayerTransform(Transform transform)
        {
            playerTransform = transform;
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
