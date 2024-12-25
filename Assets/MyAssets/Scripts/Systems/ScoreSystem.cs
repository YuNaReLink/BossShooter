using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    public class ScoreSystem : MonoBehaviour
    {
        private static ScoreSystem  instance;
        public static ScoreSystem   Instance => instance;

        [SerializeField]
        private int                 currentCount;
        public int CurrentCount => currentCount;

        private bool        changeAttack;
        public bool         ChangeAttack => changeAttack;
        public void NoActivateChangeAttack()
        {
            changeAttack = false;
        }

        [SerializeField]
        private int scoreLine;

        [SerializeField]
        private int addScoreLine;

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
                    count = 10;
                    break;
                case BulletType.LockOn:
                    count = 15;
                    break;
                case BulletType.Homing:
                    count = 20;
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
