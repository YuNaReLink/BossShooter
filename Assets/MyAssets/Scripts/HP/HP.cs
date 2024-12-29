using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// Player‚âBoss‚Ì‘Ì—Í‚ğŠÇ—‚·‚éƒNƒ‰ƒX
    /// </summary>
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
