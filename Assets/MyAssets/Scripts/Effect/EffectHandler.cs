using UnityEngine;

namespace CreateScript
{
    public enum EffectTag
    {
        Explosion,
        Hit
    }

    /*
     * Sprite型のエフェクトをオブジェクトとして生成するクラス
     */
    public class EffectHandler : MonoBehaviour
    {
        [SerializeField]
        private EffectLedger ledger;


        //再生するためだけのオブジェクトを生成する。
        //番号指定なので間違いに注意。
        //番号を指定しなかった場合は0番が再生される。
        public void Create(Vector2 pos,Vector3 scale,int i = 0)
        {
            //番号が範囲外なら無視する。
            if (i < 0 || i >= ledger.Count)
            {
                return;
            }

            ImageEffect effect = Instantiate(ledger[i],pos,Quaternion.identity);
            effect.gameObject.transform.localScale = scale;
        }
    }
}
