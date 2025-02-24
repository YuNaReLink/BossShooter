using UnityEngine;

namespace CreateScript
{
    /*
     * 真っすぐ進む弾本体のクラス
     */
    public class StraightBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        public override BulletType   BulletType => BulletType.Straight;
        private void Start()
        {
            rigidbody2D.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);
        }
        //飛ぶ方向を決定
        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
