using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �G�̏�Ԃ�ύX����N���X
    /// ��ɓG�̒e�̏�Ԃ�ύX���Ă���
    /// </summary>
    public class FormChange : MonoBehaviour
    {
        [SerializeField]
        private int stateCount = 3;

        private Launch[] launches;

        private EnemyBulletType bulletType;
        private void Awake()
        {
            launches = GetComponentsInChildren<Launch>();
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
            for(int i = 0; i < launches.Length; i++)
            {
                launches[i].SetBulleyType(bulletType);
            }
        }
    }
}
