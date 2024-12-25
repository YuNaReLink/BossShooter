using UnityEngine;

namespace CreateScript
{
    public class HP : MonoBehaviour
    {
        [SerializeField]
        private int max;
        public int Max => max;
        [SerializeField]
        private int current;
        public int Current => current;

        public float GetHPProgress()
        {
            return (float)current / max;
        }

        public void DecreaseHP(int d)
        {
            current -= d;
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
