using UnityEngine;

namespace CreateScript
{
    public class HP : MonoBehaviour
    {
        [SerializeField]
        private int maxHP;
        [SerializeField]
        private int hp;

        public void DecreaseHP(int d)
        {
            hp -= d;
        }

        public bool Death()
        {
            return hp <= 0;
        }

        private void Start()
        {
            hp = maxHP;
        }
    }
}
