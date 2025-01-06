using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * �{�X�ƃp�[�c2��HP���܂Ƃ߂ĕ\������N���X
     */
    public class BossHPUI : MonoBehaviour
    {
        //�{�X�{��
        private BossController  boss;
        //�{�X�̃p�[�c
        private BossParts[]     bossParts;
        //�ő�HP
        private int             maxHP;
        //���݂�HP
        private int             currentHP;
        //HP��Image
        [SerializeField]
        private Image           hpFill;

        public void SetBoss(BossController b,BossParts[] parts)
        {
            boss = b;
            bossParts = parts;
        }

        private void Start()
        {
            maxHP = GetMaxHP();
            currentHP = GetCurrentHP();
        }
        //���݂�HP����ő�HP�̊������o��
        private float GetHPProgress()
        {
            return (float)currentHP / maxHP;
        }
        //�{�̂ƃp�[�c2�̗̑͂����킹�čő�̗̑͂��o���֐�
        private int GetMaxHP()
        {
            int max = 0;
            for (int i = 0; i < bossParts.Length; i++)
            {
                max += bossParts[i].HP.Max;
            }
            max += boss.HP.Max;
            return max;
        }
        //�{�̂ƃp�[�c2�̗̑͂����킹�Č��݂̗̑͂��o���֐�
        private int GetCurrentHP()
        {
            int max = 0;
            for (int i = 0; i < bossParts.Length; i++)
            {
                max += bossParts[i].HP.Current;
            }
            max += boss.HP.Current;
            return max;
        }

        private void Update()
        {
            UIUpdate();
        }
        //�{�X��HP���X�V
        private void UIUpdate()
        {
            if(currentHP == GetCurrentHP()) { return; }
            currentHP = GetCurrentHP();
            hpFill.fillAmount = GetHPProgress();
        }
    }
}
