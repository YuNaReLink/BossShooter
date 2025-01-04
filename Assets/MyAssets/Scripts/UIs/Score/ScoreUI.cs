using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * スコアUIの表示を行うクラス
     */
    public class ScoreUI : MonoBehaviour
    {
        //取得したスコア
        [SerializeField]
        private int             count;
        //取得したスコアをUIとして表示する数値
        [SerializeField]
        private float           viewCount;
        private float           countSpeed = 100f;
        //テキスト
        private Text            text;
        //数値以外に文字を書けば数値の前に表示させる
        [SerializeField]
        private string          baseText;
        //取得、表示できる最大のスコア数値
        private int             maxViewScore = 999999;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void Start()
        {
            if(ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }
        //取得したスコアをテキストに出力
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
                viewCount+= countSpeed * Time.deltaTime;
                if(count < viewCount)
                {
                    viewCount = count;
                }
            }
            //テキストに出力
            text.text = baseText + String.Format("{0:D6}", (int)viewCount);
        }

        private void Update()
        {
            if (ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }
    }
}
