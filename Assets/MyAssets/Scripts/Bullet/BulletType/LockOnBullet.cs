using UnityEngine;

namespace CreateScript
{
    /*
     * ターゲットに向かって飛ぶ弾本体のクラス
     */
    public class LockOnBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        private Transform               target;

        public override BulletType   BulletType => BulletType.LockOn;

        //Start時にターゲットと自分の座標を使ってターゲットまで飛ばす処理を行う
        private void Start()
        {
            direction = target.position - transform.position;
            rigidbody2D.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);
        }
        //ターゲットを設定
        public void SetPlayerTransform(Transform transform)
        {
            target = transform;
        }
        //方向を設定
        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
