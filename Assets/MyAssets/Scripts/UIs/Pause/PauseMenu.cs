using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �|�[�Y��L���A�����ɂ��鏈�����s���N���X
    /// SE�⎞�Ԃ��~�߂鏈���������ōs��
    /// </summary>
    [RequireComponent(typeof(Pause))]
    public class PauseMenu : MonoBehaviour
    {


        public static PauseMenu Instance { get; private set; }


        //�����~�߂邽�߂̃R���|�[�l���g
        private Pause pause;

        //���ʉ��Đ��p�̃R���|�[�l���g
        [SerializeField]
        private SEManager seManager;

        private void Awake()
        {
            //�V���O���g���p�̕ϐ��ɑ������B
            Instance = this;



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



        //���j���[�I������
        public void Close()
        {

            //���ʉ��̍Đ�
            seManager.Play(1);

            //�I�u�W�F�N�g�̔j��
            Destroy(gameObject);
        }
    }
}
