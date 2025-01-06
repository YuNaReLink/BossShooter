using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * プレイヤーの残機を表示するUI
     */
    public class PlayerLifeUI : MonoBehaviour
    {
        //表示するライフのカウントを行う
        private int     life = 0;
        //表示するテキスト
        private Text    text;
        //countとは別に表示する文字を指定するstring型
        [SerializeField]
        private string  baseText;
        //カウントしない値の最低ライン
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
