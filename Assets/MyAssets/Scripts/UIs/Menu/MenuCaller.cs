using UnityEngine;

namespace CreateScript
{
    public class MenuCaller : MonoBehaviour
    {
        /*Serialized*/

        //���j���[���������邽�߂̃L�����o�X
        //�L�����o�X����������ꍇ�ȂǁA����ɐݒ肳���ƍ���ꍇ�͎蓮�Őݒ�B
        //�L�����o�X���P�̂Ȃ疢�ݒ�ł��Q�Ƃ��Ď擾�B
        [SerializeField]
        private Canvas canvas;

        private SEManager seManager;

        private void Awake()
        {
            seManager = GetComponent<SEManager>();
        }

        private Canvas TargetCanvas
        {
            get
            {
                if (canvas == null)
                {
                    /*�g�����W�V�����p�̃L�����o�X�����O���đI��*/

                    Canvas c = FindObjectOfType<Canvas>();
                    if (c != null)
                    {
                        canvas = c;
                    }
                }
                return canvas;
            }
        }

        //�������郁�j���[�̃v���n�u
        [SerializeField]
        private PauseMenu menuPrefab;

        //���j���[�Ăяo��
        public void Call()
        {
            //public�ō쐬���Ă��邽��null�`�F�b�N�����ށB
            if (PauseMenu.Instance != null)
            {
                return;
            }
            seManager.Play(1);
            //�Ώۂ̃L�����o�X�ɐ�������B
            PauseMenu menu = Instantiate(menuPrefab, TargetCanvas.transform);
        }

        //���j���[�̏I��
        public void Close()
        {
            seManager.Play(1);
            //public�ō쐬���Ă��邽��null�`�F�b�N�����݂Ȃ������B
            PauseMenu.Instance?.Close();
        }
    }
}
