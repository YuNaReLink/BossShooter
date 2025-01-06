using UnityEngine;

namespace CreateScript
{
    /*
     * 弾やエフェクト、SEなどで使ってる台帳のベース台帳
     */
    public class LedgerBase<T> : ScriptableObject
    {
        [SerializeField]
        private T[] values;
        public T[] Values { get => values; }
        public T this[int i] { get => values[i]; }
        public int Count { get => values.Length; }
    }
}
