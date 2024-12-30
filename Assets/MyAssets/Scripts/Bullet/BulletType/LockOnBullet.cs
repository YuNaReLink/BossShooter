using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ターゲットに向かって飛ぶ弾本体のクラス
    /// </summary>
    public class LockOnBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        private Transform               playerTransform;

        protected override BulletType   BulletType => BulletType.LockOn;

        //Start時にターゲットと自分の座標を使ってターゲットまで飛ばす処理を行う
        private void Start()
        {
            direction = playerTransform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(GetComponent<Rigidbody2D>());
        }
        //ターゲットを設定
        public void SetPlayerTransform(Transform transform)
        {
            playerTransform = transform;
        }
        //方向を設定
        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
