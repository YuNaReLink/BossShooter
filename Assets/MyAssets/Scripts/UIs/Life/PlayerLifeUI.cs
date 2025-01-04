using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * �v���C���[�̎c�@��\������UI
     */
    public class PlayerLifeUI : MonoBehaviour
    {

        private int     life = 0;

        private Text    text;

        [SerializeField]
        private string  baseText;

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
