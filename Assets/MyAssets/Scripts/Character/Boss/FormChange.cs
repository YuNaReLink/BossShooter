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
        private int             stateCount = 3;

        private BossSetup       boss;

        private BossMovement   movement;

        private Launch[]        launches;

        private EnemyBulletType bulletType;
        //��Ԃ��ω��������̈ړ��X�s�[�h�̒l
        [SerializeField]
        private float[]         formMoveSpeeds; 
        private void Awake()
        {
            boss = GetComponent<BossSetup>();
            launches = GetComponentsInChildren<Launch>();

            movement = boss.Movement;
        }

        private void Start()
        {
            stateCount = 0;
            SetForm(0);
        }

        public void SetForm(int count)
        {
            stateCount += count;
            switch (stateCount)
            {
                case 0:
                    bulletType = EnemyBulletType.LockOn;
                    movement.SetSpeed(formMoveSpeeds[stateCount]);
                    break;
                case 1:
                    bulletType = EnemyBulletType.Random;
                    movement.SetSpeed(formMoveSpeeds[stateCount]);
                    break;
                case 2:
                    bulletType = EnemyBulletType.Homing;
                    movement.SetSpeed(formMoveSpeeds[stateCount]);
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