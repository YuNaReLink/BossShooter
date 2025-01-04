using UnityEngine;

namespace CreateScript
{
    /*
     * ボスのパーツ部分の管理を行うクラス
     * 主にHP処理とダメージ処理のみ
     */
    public class BossParts : MonoBehaviour
    {
        //HP処理
        private HP              hp;
        public HP               HP => hp;
        //カラー変更処理
        private ColorChanger    colorChanger;

        private EffectManager   effectManager;

        private Vector3         effectScale = new Vector3(10f,10f,10f);

        private SEManager       seManager;

        private void Awake()
        {
            hp = GetComponent<HP>();
            colorChanger = GetComponent<ColorChanger>();
            effectManager = GetComponent<EffectManager>();
            seManager = GetComponent<SEManager>();
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
                seManager.Play();
                effectManager.Create(transform.position, effectScale);
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
