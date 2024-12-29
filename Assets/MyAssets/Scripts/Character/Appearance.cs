using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ����������X���������߂�^�O
    /// </summary>
    public enum AppearanceTypeX
    {
        Null = -1,
        Left,
        Right
    }
    /// <summary>
    /// ����������Y���������߂�^�O
    /// </summary>
    public enum AppearanceTypeY
    {
        Null = -1,
        Up,
        Down
    }
    /// <summary>
    /// �I�u�W�F�N�g���J�����̑傫�������ɂ����㉺���E�ɓ������ēo�ꂳ����
    /// �������s���N���X
    /// </summary>
    public class Appearance : MonoBehaviour
    {
        [SerializeField]
        private AppearanceTypeX     appearanceTypeX;
        [SerializeField]
        private AppearanceTypeY     appearanceTypeY;

        private new Camera          camera;

        private Vector2             screenBounds => camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

        private Vector2             goalPostion = Vector2.zero;

        private new Collider2D      collider;

        private ColorChanger        colorChanger;

        private void Awake()
        {
            camera = Camera.main;
            collider = GetComponent<Collider2D>();
            collider.enabled = false;
            colorChanger = GetComponent<ColorChanger>();
        }

        private void Start()
        {
            switch (appearanceTypeX)
            {
                case AppearanceTypeX.Null:
                    goalPostion.x = 0;
                    break;
                case AppearanceTypeX.Left:
                    goalPostion.x = -screenBounds.x / 2f;
                    break;
                case AppearanceTypeX.Right:
                    goalPostion.x = screenBounds.x / 2f;
                    break;
            }
            switch (appearanceTypeY)
            {
                case AppearanceTypeY.Null:
                    goalPostion.y = 0;
                    break;
                case AppearanceTypeY.Up:
                    goalPostion.y = screenBounds.y / 2f;
                    break;
                case AppearanceTypeY.Down:
                    goalPostion.y = -screenBounds.y / 2f;
                    break;
            }
            colorChanger.ColorChangeStart();
        }


        private void Update()
        {
            transform.position = Vector2.Lerp(transform.position, goalPostion, Time.deltaTime * 5f);
            Vector2 sub = (Vector2)transform.position - goalPostion;
            colorChanger.LoopColorChangeStart();
            if(sub.magnitude < 0.01f)
            {
                colorChanger.Finsh();
                collider.enabled = true;
                GameController.Instance.SetGameStop(false);
                Destroy(colorChanger);
                Destroy(this);
            }
        }
    }
}
