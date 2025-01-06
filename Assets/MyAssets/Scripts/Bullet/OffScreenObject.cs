using UnityEngine;

namespace CreateScript
{
    /*
     * �I�u�W�F�N�g����ʊO�ɏo����폜����N���X
     * ���݂͒e�ɂ����g�p
     */
    public class OffScreenObject : MonoBehaviour
    {
        //��ʓ��̍��W���擾���邽�߂̃J�����錾
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
                //��ʊO��������I�u�W�F�N�g���폜
                Destroy(gameObject);
            }
        }
        //��ʊO���𒲂ׂ�
        private bool Check(Vector2 screenBounds)
        {
            Vector3 pos = transform.position;
            return pos.x < -screenBounds.x || pos.x > screenBounds.x ||
            pos.y < -screenBounds.y || pos.y > screenBounds.y;
        }

    }
}
