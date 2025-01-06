using UnityEngine;

namespace CreateScript
{
    /*
     * �e��G�t�F�N�g�ASE�ȂǂŎg���Ă�䒠�̃x�[�X�䒠
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
