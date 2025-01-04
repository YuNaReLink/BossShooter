using UnityEngine;

namespace CreateScript
{
    /*
     * Player��Boss�̗̑͂��Ǘ�����N���X
     */
    public class HP : MonoBehaviour
    {
        [SerializeField]
        private int     max;
        public int      Max => max;
        [SerializeField]
        private int     current;
        public int      Current => current;

        public void DecreaseHP()
        {
            current--;
        }

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
