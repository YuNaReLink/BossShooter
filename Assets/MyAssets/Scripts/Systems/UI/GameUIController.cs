using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ゲームのUIを管理するクラス
    /// </summary>
    public class GameUIController : MonoBehaviour
    {
        private static GameUIController     instance;
        public static GameUIController      Instance => instance;

        
        private Canvas                      canvas;
        //結果画面で使うクラス
        [SerializeField]
        private TextOutput                  resultTextOutput;

        public void CreateResultText(string t)
        {
            if(canvas == null) { return; }
            GameObject g = Instantiate(resultTextOutput.gameObject,canvas.transform);
            TextOutput textOutput = g.GetComponent<TextOutput>();
            textOutput.SetText(t);
        }

        private void Awake()
        {
            instance = this;

            canvas = FindObjectOfType<Canvas>();
        }
    }
}
