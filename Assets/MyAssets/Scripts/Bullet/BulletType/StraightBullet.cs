using UnityEngine;

namespace CreateScript
{
    /*
     * �^�������i�ޒe�{�̂̃N���X
     */
    public class StraightBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        protected override BulletType   BulletType => BulletType.Straight;
        private void Start()
        {
            rigidbody2D.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
