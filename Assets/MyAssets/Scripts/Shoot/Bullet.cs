using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CreateScript
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Bullet : MonoBehaviour
    {
        private Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            // カメラのスクリーン境界を計算
            Vector2  screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            if (OffScreen(screenBounds))
            {
                Destroy(gameObject);
            }
        }

        private bool OffScreen(Vector2 screenBounds)
        {
            Vector3 pos = transform.position;
            return pos.x < -screenBounds.x || pos.x > screenBounds.x ||
            pos.y < -screenBounds.y || pos.y > screenBounds.y;
        }

    }
}
