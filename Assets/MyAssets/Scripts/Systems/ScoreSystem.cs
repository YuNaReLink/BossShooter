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

        [SerializeField]
        private int                 currentCount;
        public int                  CurrentCount => currentCount;

        private bool                changeAttack;
        public bool                 ChangeAttack => changeAttack;

        [SerializeField]
        private int                 scoreLine;

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
            changeAttack = false;
        }

        public void ResetScore()
        {
            currentCount = 0;
            scoreLine = 100;
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
            scoreLine = addScoreLine;
        }

        public void AddScore(BulletType type)
        {
            int count = 0;
            switch (type)
            {
                case BulletType.Random:
                case BulletType.Straight:
                    count = smallScore;
                    break;
                case BulletType.LockOn:
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
            if (changeAttack) { return; }
            if(currentCount >= scoreLine)
            {
                changeAttack = true;
                scoreLine += addScoreLine;
            }
        }
    }

}
