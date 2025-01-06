using UnityEngine;

namespace CreateScript
{
    /*
     * �Q�[����UI���Ǘ�����N���X
     */
    public class GameUIController : MonoBehaviour
    {
        private static GameUIController     instance;
        public static GameUIController      Instance => instance;

        
        private Canvas                      canvas;
        //���ʉ�ʂŎg���N���X
        [SerializeField]
        private TextOutput                  resultTextOutput;

        private string SetGameResult()
        {
            string result = "";
            switch (GlobalManager.Instance.ResultType)
            {
                case ResultType.GameClear:
                    result = "GAMECLEAR";
                    break;
                case ResultType.GameOver:
                    result = "GAMEOVER";
                    break;
                default:
                    result = "ERROR";
                    break;
            }
            return result;
        }
        //�Q�[���I�����ɃN���A�������I�[�o�[�������̃e�L�X�g���o�͂��鏈��
        public void CreateResultText()
        {
            if(canvas == null) { return; }
            string t = SetGameResult();
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
