using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
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

        // Start is called before the first frame update
        private void Start()
        {
            BombCountTextOutput(GameController.Instance.BombCount);
        }

        // Update is called once per frame
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
