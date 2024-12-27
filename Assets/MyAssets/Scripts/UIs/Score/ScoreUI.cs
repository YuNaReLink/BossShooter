using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private int         count;

        [SerializeField]
        private int         viewCount;

        private Text        text;

        [SerializeField]
        private string      baseText;

        private void Awake()
        {
            text = GetComponent<Text>();
        }
        // Start is called before the first frame update
        private void Start()
        {
            if(ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }

        private void ScoreTextOutput(int score)
        {
            if(score == viewCount) { return; }
            count = score;
            if(count >= viewCount) 
            {
                viewCount++;
                if(count < viewCount)
                {
                    viewCount = count;
                }
            }
            text.text = baseText + String.Format("{0:D6}", viewCount);
        }

        private void Update()
        {
            if (ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }
    }
}
