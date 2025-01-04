using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// SEをオブジェクトとして生成するクラス
    /// オブジェクトにアタッチして使う
    /// </summary>
    public class SEManager : MonoBehaviour
    {
        [SerializeField]
        private AudioLedger     ledger;

        [SerializeField]
        private float           volum = 1.0f;


        //再生するためだけのオブジェクトを生成する。
        //番号指定なので間違いに注意。
        //番号を指定しなかった場合は0番が再生される。
        public void Play(int i = 0)
        {
            //番号が範囲外なら無視する。
            if (i < 0 || i >= ledger.Count)
            {
                return;
            }

            //空のオブジェクトを生成する。
            GameObject o = new("SE Player");

            //コンポーネントを括り付ける。
            SEPlayer se = o.AddComponent<SEPlayer>();

            //鳴らす。
            se.Play(ledger[i],volum);
        }
    }
}
