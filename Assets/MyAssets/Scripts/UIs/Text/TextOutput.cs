using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * Text�I�u�W�F�N�g�ɃA�^�b�`����I�u�W�F�N�g
     * ��Ɍ��ʉ�ʂŎg�p
     * ����Text�I�u�W�F�N�g�ł��g�p��
     */
    public class TextOutput : MonoBehaviour
    {
        [SerializeField]
        private Text text;


        public void SetText(string t)
        {
            text.text = t;
        }
    }
}
