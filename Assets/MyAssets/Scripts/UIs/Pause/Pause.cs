using UnityEngine;

namespace CreateScript
{
    /*
     * �|�[�Y�������ɃQ�[�����Ԃ��~�߂違�i�߂鏈�����s���N���X
     */
    public class Pause : MonoBehaviour
    {

        //�|�[�Y�����܂ł̑ҋ@����
        private float wait = 0;


        private void Update()
        {
            //�����̑ҋ@���ȊO�̓X�L�b�v����悤�ɂ��Ă���B
            if (wait <= 0)
            {
                return;
            }

            //Time.timeScale�̉e�����󂯂Ȃ��A���m�Ȏ��Ԃ��擾���ăJ�E���g�_�E�����s���B
            wait -= Time.unscaledDeltaTime;

            //�ҋ@���Ԃ��I��������|�[�Y�𖳌�������
            if (wait <= 0)
            {
                Disable();
            }
        }

        //�j�����Ƀ|�[�Y�𖳌�������B
        private void OnDestroy()
        {
            Disable();
        }

        //�|�[�Y�̗L����
        //Time.timeScale��0�ɐݒ肷�邱�ƂŁA�قڑS�ẴI�u�W�F�N�g�̓�����~�ł���B
        public void Enable()
        {
            Time.timeScale = 0.0f;
        }

        //�|�[�Y�̖�����
        //�����Ƀ|�[�Y��Ԃ���������B
        public void Disable()
        {
            Time.timeScale = 1.0f;
        }

        //�|�[�Y�̖�����
        //�����̎��Ԃ����ҋ@���Ă���|�[�Y��Ԃ���������B
        public void Disable(float w)
        {
            //0�ȉ����󂯎�����ꍇ�͑����ɉ�������B
            if (w <= 0)
            {
                Disable();
                return;
            }

            //�ҋ@���Ԃ�ݒ肵�A�c���Update�ɔC����B
            wait = w;
        }
    }
}
