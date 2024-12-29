using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ��ʊO�ɏo���Ȃ��悤�ɂ���N���X
    /// ������Z�b�g�����I�u�W�F�N�g�͉�ʊO�ɏo���Ȃ��悤�ɂȂ�
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
            // �J�����̃X�N���[�����E���v�Z
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x + widthOffset, screenBounds.x - widthOffset),
                Mathf.Clamp(transform.position.y, -screenBounds.y + heightOffset, screenBounds.y - heightOffset));
        }
    }
}
