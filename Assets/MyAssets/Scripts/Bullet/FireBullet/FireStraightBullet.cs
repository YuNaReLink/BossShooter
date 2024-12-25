using UnityEngine;

namespace CreateScript
{
    public interface IFireBullet
    {
        void Setup(IBaseLaunch launch);
        void DoUpdate(float time);
        void Fire(Transform target);
        public void DecreaseCoolDownCount(float count);
    }

    [System.Serializable]
    public class FireStraightBullet : IFireBullet
    {
        private Transform transform;

        private Timer timer = new Timer();

        private BulletData bulletData;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;

        private float minCount = 0.2f;
        public void DecreaseCoolDownCount(float count)
        {
            fireCoolDownCount -= count;
            if(fireCoolDownCount <= minCount)
            {
                fireCoolDownCount = minCount;
            }
        }

        [SerializeField]
        private Vector2 direction = Vector2.zero;

        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bulletData = launch.BulletData;
        }

        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bulletData.Bullets[(int)PlayerBulletType.Straight].gameObject, transform.position,Quaternion.identity);
            StraightBullet straightBullet = g.GetComponent<StraightBullet>();
            if(straightBullet != null)
            {
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Player);
                straightBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
