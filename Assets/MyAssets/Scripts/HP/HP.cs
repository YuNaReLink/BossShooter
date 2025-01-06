using UnityEngine;

namespace CreateScript
{
    /*
     * Player��Boss�̗̑͂��Ǘ�����N���X
     * HP�̌��������A�ő�HP�A���݂�HP�������Ă���
     * �e�L�����N�^�[�ɃA�^�b�`����ΌʂɎg�����Ƃ��ł���
     */
    public class HP : MonoBehaviour
    {
        //HP�̍ő�
        [SerializeField]
        private int     max;
        public int      Max => max;
        //���݂�HP
        [SerializeField]
        private int     current;
        public int      Current => current;
        //HP�����炷
        public void DecreaseHP()
        {
            current--;
        }
        //HP��0�Ŏ��S���Ă邩�`�F�b�N
        public bool Death()
        {
            return current <= 0;
        }

        private void Start()
        {
            current = max;
        }
    }
}
