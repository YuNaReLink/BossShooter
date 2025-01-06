using UnityEngine;

namespace CreateScript
{
    /*
     * �|�[�Y��L���A�����ɂ��鏈�����s���N���X
     * SE�⎞�Ԃ��~�߂鏈���������ōs��
     */
    [RequireComponent(typeof(Pause))]
    public class PauseMenu : MonoBehaviour
    {


        public static PauseMenu Instance { get; private set; }


        //�����~�߂邽�߂̃R���|�[�l���g
        private Pause pause;

        //���ʉ��Đ��p�̃R���|�[�l���g
        [SerializeField]
        private SEHandler seHandler;

        private void Awake()
        {
            //�V���O���g���p�̕ϐ��ɑ������B
            Instance = this;



            seHandler = GetComponent<SEHandler>();
            pause = GetComponent<Pause>();
        }

        private void Start()
        {
            //�J�n���ɉ���炷�B
            seHandler.Play((int)ButtonSETag.Select);

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
            seHandler.Play((int)ButtonSETag.Select);

            //�I�u�W�F�N�g�̔j��
            Destroy(gameObject);
        }
    }
}
