using UnityEngine;

namespace CreateScript
{
    /*
     * PlayerやBossの体力を管理するクラス
     * HPの減少処理、最大HP、現在のHPを持っている
     * 各キャラクターにアタッチすれば個別に使うことができる
     */
    public class HP : MonoBehaviour
    {
        //HPの最大
        [SerializeField]
        private int     max;
        public int      Max => max;
        //現在のHP
        [SerializeField]
        private int     current;
        public int      Current => current;
        //HPを減らす
        public void DecreaseHP()
        {
            current--;
        }
        //HPが0で死亡してるかチェック
        public bool Death()
        {
            return current <= 0;
        }

        private void Start()
        {
            current = max;
        }
    }
}
