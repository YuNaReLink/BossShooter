using UnityEngine;

namespace CreateScript
{
    /*
     * �e����ʊO�ɏo����폜����N���X
     */
    public class OffScreenObject : MonoBehaviour
    {
        private new Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            // �J�����̃X�N���[�����E���v�Z
            Vector2  screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            if (Check(screenBounds))
            {
                Destroy(gameObject);
            }
        }

        private bool Check(Vector2 screenBounds)
        {
            Vector3 pos = transform.position;
            return pos.x < -screenBounds.x || pos.x > screenBounds.x ||
            pos.y < -screenBounds.y || pos.y > screenBounds.y;
        }

    }
}
