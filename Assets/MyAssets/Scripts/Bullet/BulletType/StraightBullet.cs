using UnityEngine;

namespace CreateScript
{
    public class StraightBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        protected override BulletType   BulletType => BulletType.Straight;
        private void Start()
        {
            GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(GetComponent<Rigidbody2D>());
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
