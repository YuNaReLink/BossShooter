using UnityEngine;

namespace CreateScript
{
    public class LockOnBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        private Transform               playerTransform;

        protected override BulletType   BulletType => BulletType.LockOn;


        private void Start()
        {
            direction = playerTransform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(GetComponent<Rigidbody2D>());
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
