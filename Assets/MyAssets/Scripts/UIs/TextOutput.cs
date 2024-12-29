using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// Textオブジェクトにアタッチするオブジェクト
    /// 主に結果画面で使用
    /// 他のTextオブジェクトでも使用可
    /// </summary>
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
