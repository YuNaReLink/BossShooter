using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ボスのHPUIを生成するクラス
    /// ボス本体のオブジェクトにアタッチし生成し
    /// 終わったら削除
    /// </summary>
    public class CreateBossHPUI : MonoBehaviour
    {
        private BossController  boss;

        private BossParts[]     parts;

        [SerializeField]
        private BossHPUI        bossHPUI;

        private void Awake()
        {
            boss = GetComponent<BossController>();
            BossParts[] bossParts = GetComponentsInChildren<BossParts>();
            if(bossParts != null)
            {
                parts = bossParts;
            }

            Canvas canvas = FindObjectOfType<Canvas>();
            if(canvas != null)
            {
                BossHPUI hp = Instantiate(bossHPUI, canvas.transform);
                hp.SetBoss(boss, parts);
            }

            Destroy(this);
        }
    }
}
