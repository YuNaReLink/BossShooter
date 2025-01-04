using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * �X�R�AUI�̕\�����s���N���X
     */
    public class ScoreUI : MonoBehaviour
    {
        //�擾�����X�R�A
        [SerializeField]
        private int             count;
        //�擾�����X�R�A��UI�Ƃ��ĕ\�����鐔�l
        [SerializeField]
        private float           viewCount;
        private float           countSpeed = 100f;
        //�e�L�X�g
        private Text            text;
        //���l�ȊO�ɕ����������ΐ��l�̑O�ɕ\��������
        [SerializeField]
        private string          baseText;
        //�擾�A�\���ł���ő�̃X�R�A���l
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
        //�擾�����X�R�A���e�L�X�g�ɏo��
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
                viewCount+= countSpeed * Time.deltaTime;
                if(count < viewCount)
                {
                    viewCount = count;
                }
            }
            //�e�L�X�g�ɏo��
            text.text = baseText + String.Format("{0:D6}", (int)viewCount);
        }

        private void Update()
        {
            if (ScoreSystem.Instance == null) { return; }
            ScoreTextOutput(ScoreSystem.Instance.CurrentCount);
        }
    }
}
