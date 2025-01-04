using UnityEngine;

namespace CreateScript
{
    /*
     * 弾の画像オブジェクトにアタッチするもの
     * Bulletクラスで指定されてる方向を元に
     * オブジェクトの向きを変更する処理
     */
    public class BulletImage : MonoBehaviour
    {
        public void SetRotation(Rigidbody2D rigidbody2D)
        {
            // 移動方向（速度ベクトル）を取得
            Vector2 velocity = rigidbody2D.velocity;

            // 速度が十分小さい場合は回転を維持
            if (velocity.sqrMagnitude < 0.01f)
            {
                return;
            }

            // 方向ベクトルから角度を計算 (ラジアンを度に変換)
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

            // 対象オブジェクトを回転
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
