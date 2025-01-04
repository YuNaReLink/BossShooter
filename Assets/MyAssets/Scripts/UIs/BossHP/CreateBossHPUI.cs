using UnityEngine;

namespace CreateScript
{
    /*
     * �{�X��HPUI�𐶐�����N���X
     * �{�X�{�̂̃I�u�W�F�N�g�ɃA�^�b�`��������
     * �I�������폜
     */
    public class CreateBossHPUI : MonoBehaviour
    {
        private BossController  boss;

        private BossParts[]     parts;

        [SerializeField]
        private BossHPUI        bossHPUI;

        private void Awake()
        {
            boss = GetComponent<BossController>();

            parts = GetComponentsInChildren<BossParts>();

            Canvas canvas = FindObjectOfType<Canvas>();
            if(canvas == null)
            {
                Debug.LogError("Canvas������܂���!");
            }
            else
            {
                BossHPUI hp = Instantiate(bossHPUI, canvas.transform);
                hp.SetBoss(boss, parts);
            }

            Destroy(this);
        }
    }
}
