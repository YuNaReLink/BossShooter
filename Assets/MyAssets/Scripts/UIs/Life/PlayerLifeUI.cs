using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * �v���C���[�̎c�@��\������UI
     */
    public class PlayerLifeUI : MonoBehaviour
    {
        //�\�����郉�C�t�̃J�E���g���s��
        private int     life = 0;
        //�\������e�L�X�g
        private Text    text;
        //count�Ƃ͕ʂɕ\�����镶�����w�肷��string�^
        [SerializeField]
        private string  baseText;
        //�J�E���g���Ȃ��l�̍Œ჉�C��
        private int     noActivateLife = -1;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        // Start is called before the first frame update
        void Start()
        {
            life = GameController.Instance.PlayerLife;
            LifeTextOutput(life);
        }

        public void LifeTextOutput(int life)
        {
            text.text = baseText + life.ToString();
        }

        private void Update()
        {
            if (life == GameController.Instance.PlayerLife) { return; }
            life = GameController.Instance.PlayerLife;
            if(life <= noActivateLife) { return; }
            LifeTextOutput(life);
        }
    }
}
