using UnityEngine;

namespace CreateScript
{
    public class OnScreenMove : MonoBehaviour
    {
        private Camera camera;

        [SerializeField]
        private float width;
        [SerializeField]
        private float height;

        private void Awake()
        {
            camera = Camera.main;
        }

        // Update is called once per frame
        private void Update()
        {
            // カメラのスクリーン境界を計算
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x + width, screenBounds.x - width),
                Mathf.Clamp(transform.position.y, -screenBounds.y + height, screenBounds.y - height));
        }
    }
}
