using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �Q�[�����ƌ��ʉ�ʂŎg�p����X�R�A�̊Ǘ����s���N���X
    /// 1�������݂��Ȃ��̂ƕ����̃V�[���Ŏg�p���邽��
    /// �O���[�o���̃I�u�W�F�N�g�ɃA�^�b�`
    /// </summary>
    public class ScoreSystem : MonoBehaviour
    {
        private static ScoreSystem  instance;
        public static ScoreSystem   Instance => instance;
        //���ݎ擾���̃X�R�A
        [SerializeField]
        private int                 currentCount;
        public int                  CurrentCount => currentCount;
        //�v���C���[�̒e�̔��ˊԊu��ύX���Ă������̃t���O
        private bool                changePlayerBullet;
        public bool                 ChangePlayerBullet => changePlayerBullet;
        //�v���C���[�̍U���Ԋu���グ�邩�ǂ������C���̐��l
        [SerializeField]
        private int                 currentScoreLine;
        //���C�������X�R�A������������addScoreLine��Line�𑝉�
        [SerializeField]
        private int                 addScoreLine;

        //�G�̒e��j�󂵂����Ɏ擾�ł���X�R�A�̐��l
        [SerializeField]
        private int                 smallScore;
        [SerializeField]
        private int                 middleScore;
        [SerializeField]
        private int                 bigScore;
        public void NoActivateChangeAttack()
        {
            changePlayerBullet = false;
        }

        public void ResetScore()
        {
            currentCount = 0;
            currentScoreLine = 100;
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }

        private void Start()
        {
            currentScoreLine = addScoreLine;
        }

        public void AddScore(BulletType type)
        {
            int count = 0;
            switch (type)
            {
                case BulletType.LockOn:
                case BulletType.Straight:
                    count = smallScore;
                    break;
                case BulletType.Random:
                    count = middleScore;
                    break;
                case BulletType.Homing:
                    count = bigScore;
                    break;
            }
            currentCount += count;
            CurrentScoreCheck();
        }

        private void CurrentScoreCheck()
        {
            if (changePlayerBullet) { return; }
            if(currentCount >= currentScoreLine)
            {
                changePlayerBullet = true;
                currentScoreLine += addScoreLine;
            }
        }
    }

}
