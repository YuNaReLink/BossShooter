using UnityEngine;

namespace CreateScript
{
    /*
     * ボスのパーツ部分の管理を行うクラス
     * 主にHP処理とダメージ処理のみ
     */
    public class BossParts : MonoBehaviour,BossDamager
    {
        //HP処理
        private HP              hp;
        //ボスのHPをUIで表示するためのpublic関数
        public HP               HP => hp;
        //カラー変更処理
        private ColorChanger    colorChanger;
        //エフェクト処理
        private EffectHandler   effectManager;
        //エフェクト処理時のエフェクトの大きさの比率
        private Vector3         effectScale = new Vector3(10f,10f,10f);
        //SE処理
        private SEHandler       seHandler;

        private void Awake()
        {
            hp = GetComponent<HP>();
            colorChanger = GetComponent<ColorChanger>();
            effectManager = GetComponent<EffectHandler>();
            seHandler = GetComponent<SEHandler>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Damage(collision);
        }
        //ダメージ処理
        private void Damage(Collider2D collision)
        {
            BaseBullet bullet = collision.GetComponent<BaseBullet>();
            if (bullet == null || bullet.ShooterType == ShopterType.Enemy) { return; }
            hp.DecreaseHP();
            colorChanger.ColorChangeStart();
            if (hp.Death())
            {
                seHandler.Play();
                effectManager.Create(transform.position, effectScale);
                Death();
            }
        }
        //ボスのパーツを消す処理
        private void Death()
        {
            FormChange formChange = GetComponentInParent<FormChange>();
            formChange.SetForm(1);
            Destroy(gameObject);
        }
    }
}
