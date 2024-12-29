using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 画面外に出られないようにするクラス
    /// これをセットしたオブジェクトは画面外に出られないようになる
    /// </summary>
    public class OnScreenMove : MonoBehaviour
    {
        private new Camera      camera;

        [SerializeField]
        private float           widthOffset;
        [SerializeField]
        private float           heightOffset;

        private void Awake()
        {
            camera = Camera.main;
        }


        private void Update()
        {
            // カメラのスクリーン境界を計算
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x + widthOffset, screenBounds.x - widthOffset),
                Mathf.Clamp(transform.position.y, -screenBounds.y + heightOffset, screenBounds.y - heightOffset));
        }
    }
}
