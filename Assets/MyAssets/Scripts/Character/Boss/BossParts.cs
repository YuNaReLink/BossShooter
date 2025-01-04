using UnityEngine;

namespace CreateScript
{
    /*
     * �{�X�̃p�[�c�����̊Ǘ����s���N���X
     * ���HP�����ƃ_���[�W�����̂�
     */
    public class BossParts : MonoBehaviour
    {
        //HP����
        private HP              hp;
        public HP               HP => hp;
        //�J���[�ύX����
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
        //�_���[�W����
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
