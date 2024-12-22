using System.Collections;
using System.Collections.Generic;
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
        private AppearanceTypeX appearanceTypeX;
        [SerializeField]
        private AppearanceTypeY appearanceTypeY;

        private new Camera camera;

        private Vector2 screenBounds => camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

        private Vector2 goalPostion = Vector2.zero;

        private void Awake()
        {
            camera = Camera.main;
        }
        // Start is called before the first frame update
        void Start()
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
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.Lerp(transform.position, goalPostion, Time.deltaTime * 5f);
            Vector2 sub = (Vector2)transform.position - goalPostion;
            if(sub.magnitude < 0.01f)
            {
                GameController.Instance.SetGameStop(false);
                Destroy(this);
            }
        }
    }
}
