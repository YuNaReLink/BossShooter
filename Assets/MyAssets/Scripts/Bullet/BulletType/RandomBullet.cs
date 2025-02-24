using UnityEngine;

namespace CreateScript
{
    /*
     * ランダムな方向に飛ばす弾のクラス
     * 現状はまっすぐ飛ぶ弾とほぼ同じ
     */
    public class RandomBullet : BaseBullet
    {
        private Vector2 direction = Vector2.zero;

        public override BulletType BulletType => BulletType.Random;
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
