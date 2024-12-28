using UnityEngine;

namespace CreateScript
{
    [RequireComponent(typeof(Pause))]
    public class PauseMenu : MonoBehaviour
    {

        //�V���O���g��
        public static PauseMenu Instance { get; private set; }

        /*Serialized*/
        [SerializeField]
        private SceneList next;

        //���ʉ��Đ��p�̃R���|�[�l���g
        //private SEManager se;

        //�����~�߂邽�߂̃R���|�[�l���g
        private Pause pause;

        [SerializeField]
        private SEManager seManager;

        private void Awake()
        {
            //�V���O���g���p�̕ϐ��ɑ������B
            Instance = this;

            /*�e�R���|�[�l���g�̎擾*/

            seManager = GetComponent<SEManager>();
            pause = GetComponent<Pause>();
        }

        private void Start()
        {
            //�J�n���ɉ���炷�B
            seManager.Play(1);

            //�|�[�Y��L��������B
            pause.Enable();
        }

        private void OnDestroy()
        {
            //�I�u�W�F�N�g�̔j�����V���O���g���p�ϐ��ɓ`����B
            //������A���g�ȊO�������Ă����ꍇ�͉������Ȃ��B
            if (Instance == this)
            {
                Instance = null;
            }
        }

        /*Method*/

        //���j���[�I������
        public void Close()
        {
            //�|�[�Y�̉�����Pause.OnDestroy�Ɋ܂܂�Ă��邽�߁A�����ŏ����K�v�͖����B
            //pause.Disable();

            //���ʉ��̍Đ�
            seManager.Play(1);

            //�I�u�W�F�N�g�̔j��
            Destroy(gameObject);
        }
    }
}
