using UnityEngine;

namespace CreateScript
{
    public class MenuCaller : MonoBehaviour
    {
        /*Serialized*/

        //���j���[���������邽�߂̃L�����o�X
        //�L�����o�X����������ꍇ�ȂǁA����ɐݒ肳���ƍ���ꍇ�͎蓮�Őݒ肷��ׂ��B
        //�L�����o�X���P�̂Ȃ疢�ݒ�ł����Ȃ������B
        [SerializeField]
        private Canvas canvas;

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

        //�������郁�j���[���߂��̃V�[��
        //�I����ʂ���I����ʂɖ߂邱�Ƃ�h�����߁B
        [SerializeField]
        private SceneList returnTo = SceneList.Title;

        /*Event*/

        /*
         */
        private void Update()
        {
            ////Esc�L�[�ȊO�̏����͍s��Ȃ����߁A�Y�����Ȃ��ꍇ�͂����Œ��f���Ă���B
            //if (!InputUIAction.Instance.Pause)
            //{
            //    return;
            //}
            //
            ///*
            // * Esc�L�[�������ꂽ�ꍇ�A�ȉ��̏����ɏ]���ď������s���B
            // * �E���j���[�����݂��Ȃ��ꍇ�A���j���[���Ăяo���B
            // * �E���j���[�����݂���ꍇ�A���j���[�����B
            // */
            //
            //if (PauseMenu.Instance == null)
            //{
            //    Call();
            //}
            //else
            //{
            //    Close();
            //}
        }

        //���j���[�Ăяo��
        public void Call()
        {
            //public�ō쐬���Ă��邽��null�`�F�b�N�����ށB
            if (PauseMenu.Instance != null)
            {
                return;
            }

            //�Ώۂ̃L�����o�X�ɐ�������B
            PauseMenu menu = Instantiate(menuPrefab, TargetCanvas.transform);
        }

        //���j���[�̏I��
        public void Close()
        {
            //public�ō쐬���Ă��邽��null�`�F�b�N�����݂Ȃ������B
            PauseMenu.Instance?.Close();
        }
    }
}
