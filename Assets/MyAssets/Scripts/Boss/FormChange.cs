using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    public class FormChange : MonoBehaviour
    {
        [SerializeField]
        private int stateCount = 3;

        private Launch launch;

        private EnemyBulletType bulletType;
        private void Awake()
        {
            launch = GetComponentInChildren<Launch>();
        }

        private void Start()
        {
            stateCount = 3;
            SetForm(0);
        }

        public void SetForm(int count)
        {
            stateCount -= count;
            switch (stateCount)
            {
                case 1:
                    bulletType = EnemyBulletType.Homing;
                    break;
                case 2:
                    bulletType = EnemyBulletType.Random;
                    break;
                case 3:
                    bulletType = EnemyBulletType.LockOn;
                    break;
                default:
                    break;
            }
            launch.SetBulleyType(bulletType);
        }
    }
}
