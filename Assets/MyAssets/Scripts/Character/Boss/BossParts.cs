using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ボスのパーツ部分の管理を行うクラス
    /// 主にHP処理とダメージ処理のみ
    /// </summary>
    public class BossParts : MonoBehaviour
    {
        //HP処理
        private HP              hp;
        public HP               HP => hp;
        //ボス本体
        private BossController  boss;
        //カラー変更処理
        private ColorChanger    colorChanger;

        private void Awake()
        {
            boss = GetComponentInParent<BossController>();
            hp = GetComponent<HP>();
            colorChanger = GetComponent<ColorChanger>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }
        //ダメージ処理
        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null || bullet.ShopterType == ShopterType.Enemy) { return; }
            hp.DecreaseHP();
            colorChanger.ColorChangeStart();
            if (hp.Death())
            {
                boss.SEManager.Play();
                boss.EffectManager.Create(transform.position, boss.transform.localScale);
                Death();
            }
        }

        private void Death()
        {
            FormChange formChange = GetComponentInParent<FormChange>();
            formChange.SetForm(1);
            Destroy(gameObject);
        }
    }
}
