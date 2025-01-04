using UnityEngine;

namespace CreateScript
{
    /*
     * �V�[������InputButtonController����������ꍇ
     *�����̂Ƃ͈ႤInputButtonController���I�t�ɂ���
     *����Ȃ炱�̃R���|�[�l���g���������j���[���A�O�ƕt���Ă�
     *���̊J�������j���[�����I���ł���
     */
    public class ActivateInputButtonController : MonoBehaviour
    {
        private InputButtonController    thisInputButtonController;

        private InputButtonController[]  inputButtonController;
        //�\�����Ɍ��ݎg����{�^��������L���ɂ���
        private void OnEnable()
        {
            thisInputButtonController = GetComponent<InputButtonController>();
            inputButtonController = FindObjectsOfType<InputButtonController>();
            for (int i = 0; i < inputButtonController.Length; i++)
            {
                if (inputButtonController[i] != thisInputButtonController)
                {
                    inputButtonController[i].enabled = false;
                }
            }
        }
        //��\���Ɏ����ȊO�̃{�^����L���ɂ���
        private void OnDisable()
        {
            for (int i = 0; i < inputButtonController.Length; i++)
            {
                if (inputButtonController[i] != thisInputButtonController)
                {
                    inputButtonController[i].enabled = true;
                }
            }
        }
    }
}
