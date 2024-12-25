using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    public class PlayerLifeUI : MonoBehaviour
    {

        private int keepLife = 0;

        private Text text;

        [SerializeField]
        private string baseText;

        private int noActivateLife = -1;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        // Start is called before the first frame update
        void Start()
        {
            keepLife = GameController.Instance.PlayerLife;
            LifeTextOutput(keepLife);
        }

        public void LifeTextOutput(int life)
        {
            text.text = baseText + life.ToString();
        }

        private void Update()
        {
            if (keepLife == GameController.Instance.PlayerLife) { return; }
            keepLife = GameController.Instance.PlayerLife;
            if(keepLife <= noActivateLife) { return; }
            LifeTextOutput(keepLife);
        }
    }
}
