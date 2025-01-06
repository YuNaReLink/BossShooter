using UnityEngine;

namespace CreateScript
{
    /*
     * オブジェクトが画面外に出たら削除するクラス
     * 現在は弾にだけ使用
     */
    public class OffScreenObject : MonoBehaviour
    {
        //画面内の座標を取得するためのカメラ宣言
        private new Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            // カメラのスクリーン境界を計算
            Vector2  screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            if (Check(screenBounds))
            {
                //画面外だったらオブジェクトを削除
                Destroy(gameObject);
            }
        }
        //画面外かを調べる
        private bool Check(Vector2 screenBounds)
        {
            Vector3 pos = transform.position;
            return pos.x < -screenBounds.x || pos.x > screenBounds.x ||
            pos.y < -screenBounds.y || pos.y > screenBounds.y;
        }

    }
}
