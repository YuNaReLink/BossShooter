using UnityEngine;

namespace CreateScript
{
    /*
     * �{�X�̃p�[�c�����̊Ǘ����s���N���X
     * ���HP�����ƃ_���[�W�����̂�
     */
    public class BossParts : MonoBehaviour,BossDamager
    {
        //HP����
        private HP              hp;
        //�{�X��HP��UI�ŕ\�����邽�߂�public�֐�
        public HP               HP => hp;
        //�J���[�ύX����
        private ColorChanger    colorChanger;
        //�G�t�F�N�g����
        private EffectHandler   effectManager;
        //�G�t�F�N�g�������̃G�t�F�N�g�̑傫���̔䗦
        private Vector3         effectScale = new Vector3(10f,10f,10f);
        //SE����
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
        //�_���[�W����
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
        //�{�X�̃p�[�c����������
        private void Death()
        {
            FormChange formChange = GetComponentInParent<FormChange>();
            formChange.SetForm(1);
            Destroy(gameObject);
        }
    }
}
