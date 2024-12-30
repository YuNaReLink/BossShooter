using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// �{���̃J�E���g����\������N���X
    /// </summary>
    public class BombCountUI : MonoBehaviour
    {
        //���l�̑O�ɏo�͂��镶����
        [SerializeField]
        private string  baseText;

        private Text    text;
        //���݂̃{���̃J�E���g��ۑ����Ă鐔�l
        private int     count;


        private void Awake()
        {
            text = GetComponent<Text>();
        }


        private void Start()
        {
            BombCountTextOutput(GameController.Instance.BombCount);
        }


        private void Update()
        {
            BombCountTextOutput(GameController.Instance.BombCount);
        }

        private void BombCountTextOutput(int count)
        {
            if (this.count == count) { return; }
            this.count = count;
            text.text = baseText + this.count.ToString();
        }
    }
}
