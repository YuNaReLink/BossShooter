using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * ボスとパーツ2つのHPをまとめて表示するクラス
     */
    public class BossHPUI : MonoBehaviour
    {
        //ボス本体
        private BossController  boss;
        //ボスのパーツ
        private BossParts[]     bossParts;
        //最大HP
        private int             maxHP;
        //現在のHP
        private int             currentHP;
        //HPのImage
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
        //現在のHPから最大HPの割合を出す
        private float GetHPProgress()
        {
            return (float)currentHP / maxHP;
        }
        //本体とパーツ2つの体力を合わせて最大の体力を出す関数
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
        //本体とパーツ2つの体力を合わせて現在の体力を出す関数
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
        //ボスのHPを更新
        private void UIUpdate()
        {
            if(currentHP == GetCurrentHP()) { return; }
            currentHP = GetCurrentHP();
            hpFill.fillAmount = GetHPProgress();
        }
    }
}
