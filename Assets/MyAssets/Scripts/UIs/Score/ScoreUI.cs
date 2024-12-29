using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// スコアUIの表示を行うクラス
    /// </summary>
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private int         count;

        [SerializeField]
        private int         viewCount;

        private Text        text;

        [SerializeField]
        private string      baseText;
        //取得、表示できる最大のスコア数値
        private int         maxViewScore = 999999;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void Start()
        {
            if(ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }

        private void ScoreTextOutput(int score)
        {
            if(score == viewCount) { return; }
            count = score;
            //最大スコア越え対策
            if(count >= maxViewScore)
            {
                count = maxViewScore;
                viewCount = count;
            }
            //取得スコア分1ずつ加算する
            if(count >= viewCount) 
            {
                viewCount++;
                if(count < viewCount)
                {
                    viewCount = count;
                }
            }
            //テキストに出力
            text.text = baseText + String.Format("{0:D6}", viewCount);
        }

        private void Update()
        {
            if (ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }
    }
}
