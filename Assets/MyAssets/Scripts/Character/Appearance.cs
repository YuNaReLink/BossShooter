using UnityEngine;

namespace CreateScript
{
    /*
     * ����������X���������߂�^�O
     */
    public enum AppearanceTypeX
    {
        Null = -1,
        Left,
        Right
    }
    /*
     * ����������Y���������߂�^�O
     */
    public enum AppearanceTypeY
    {
        Null = -1,
        Up,
        Down
    }
    /*
     *�I�u�W�F�N�g���J�����̑傫�������ɂ����㉺���E�ɓ������ēo�ꂳ����
     *�������s���N���X
     */
    public class Appearance : MonoBehaviour
    {
        //�ǂ̕������瓮���������������߂�^�OX
        [SerializeField]
        private AppearanceTypeX     appearanceTypeX;
        //�ǂ̕������瓮���������������߂�^�OY
        [SerializeField]
        private AppearanceTypeY     appearanceTypeY;
        //�J����
        private new Camera          camera;
        //�X�N���[�����̐��l
        private Vector2             screenBounds => camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
        //�o�ꎞ�ɓ����S�[���n�_
        private Vector2             goalPostion = Vector2.zero;
        //�����Ă�ԃR���C�_�[���\���ɂ��邽�߂̃R���C�_�[
        private new Collider2D      collider;
        //�o�ꒆ�͖��G�Ȃ̂ŃJ���[�ύX����
        private ColorChanger        colorChanger;

        //�o�ꒆ�ɕs�v�ȏ������I�t�ɂ��邽�߂�PlayerController�錾
        private PlayerController    player;
        //������������錾
        private OnScreenMove        onScreenMove;

        private PlayerLaunch        playerLaunch;
        private void Awake()
        {
            camera = Camera.main;
            collider = GetComponent<Collider2D>();
            collider.enabled = false;
            colorChanger = GetComponent<ColorChanger>();
            SetCharacterInformation();
        }
        //�v���C���[�Ǝ��̏��擾�͂��̒��ōs��
        //�v���C���[�Ǝ��̕��Ȃ̂Ōp���Ȃ�����������̊Ǘ����l�������\�b�h
        private void SetCharacterInformation()
        {
            player = GetComponent<PlayerController>();
            onScreenMove = GetComponent<OnScreenMove>();
            playerLaunch = GetComponentInChildren<PlayerLaunch>();
            player.enabled = false;
            onScreenMove.enabled = false;
            playerLaunch.enabled = false;
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
            if (GlobalManager.Instance.IsGameStop) { return; }
            transform.position = Vector2.Lerp(transform.position, goalPostion, Time.deltaTime * 5f);
            Vector2 sub = (Vector2)transform.position - goalPostion;
            colorChanger.LoopColorChangeStart();
            if(sub.magnitude < 0.01f)
            {
                colorChanger.Finsh();
                collider.enabled = true;
                ActivateCharacterInformation();
                Destroy(colorChanger);
                Destroy(this);
            }
        }   

        //�擾��������L���ɂ���
        //�v���C���[�Ǝ��̕��Ȃ̂Ōp���Ȃ�����������̊Ǘ����l�������\�b�h
        private void ActivateCharacterInformation()
        {
            player.enabled = true;
            onScreenMove.enabled = true;
            playerLaunch.enabled = true;
        }
    }
}
