using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// �X�R�AUI�̕\�����s���N���X
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
        //�擾�A�\���ł���ő�̃X�R�A���l
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
            //�ő�X�R�A�z���΍�
            if(count >= maxViewScore)
            {
                count = maxViewScore;
                viewCount = count;
            }
            //�擾�X�R�A��1�����Z����
            if(count >= viewCount) 
            {
                viewCount++;
                if(count < viewCount)
                {
                    viewCount = count;
                }
            }
            //�e�L�X�g�ɏo��
            text.text = baseText + String.Format("{0:D6}", viewCount);
        }

        private void Update()
        {
            if (ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }
    }
}
