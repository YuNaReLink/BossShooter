using UnityEngine;

namespace CreateScript
{
    /*
     * ボスのHPUIを生成するクラス
     * ボス本体のオブジェクトにアタッチし生成し
     * 終わったら削除
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
                Debug.LogError("Canvasがありません!");
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
