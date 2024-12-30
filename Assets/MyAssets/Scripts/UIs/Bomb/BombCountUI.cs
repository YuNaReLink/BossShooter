using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// ボムのカウント数を表示するクラス
    /// </summary>
    public class BombCountUI : MonoBehaviour
    {
        //数値の前に出力する文字列
        [SerializeField]
        private string  baseText;

        private Text    text;
        //現在のボムのカウントを保存してる数値
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
