using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// ボムのカウント数を表示するクラス
    /// </summary>
    public class BombCountUI : MonoBehaviour
    {
        [SerializeField]
        private string baseText;

        private Text text;

        private int keepCount;


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
            if (keepCount == count) { return; }
            keepCount = count;
            text.text = baseText + keepCount.ToString();
        }
    }
}
