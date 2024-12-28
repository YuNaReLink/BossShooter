using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ボスのパーツ部分の管理を行うクラス
    /// 主にHP処理とダメージ処理のみ
    /// </summary>
    public class BossParts : MonoBehaviour
    {

        private HP              hp;
        public HP               HP => hp;

        private BossController  boss;

        private void Awake()
        {
            boss = GetComponentInParent<BossController>();
            hp = GetComponent<HP>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }

        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null || bullet.ShopterType == ShopterType.Enemy) { return; }
            hp.DecreaseHP();
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
