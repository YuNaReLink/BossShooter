using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �{�X�̃p�[�c�����̊Ǘ����s���N���X
    /// ���HP�����ƃ_���[�W�����̂�
    /// </summary>
    public class BossParts : MonoBehaviour
    {
        //HP����
        private HP              hp;
        public HP               HP => hp;
        //�{�X�{��
        private BossController  boss;
        //�J���[�ύX����
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
        //�_���[�W����
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
