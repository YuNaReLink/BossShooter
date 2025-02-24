using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * Textオブジェクトにアタッチするオブジェクト
     * 主に結果画面で使用
     * 他のTextオブジェクトでも使用可
     */
    public class TextOutput : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        //出力するテキストの内容を指定
        public void SetText(string t)
        {
            text.text = t;
        }
    }
}
