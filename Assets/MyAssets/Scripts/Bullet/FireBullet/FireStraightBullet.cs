using UnityEngine;

namespace CreateScript
{
    public interface IFireBullet
    {
        void Setup(Transform target);
        void DoUpdate(float time);
        void Fire(Transform target);
    }

    [System.Serializable]
    public class FireStraightBullet : IFireBullet
    {
        private Transform transform;

        private Timer timer = new Timer();

        [SerializeField]
        private BulletData bulletData;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;

        [SerializeField]
        private Vector2 direction = Vector2.zero;

        public void Setup(Transform t)
        {
            transform = t;
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
                straightBullet.SetShooterTransform(transform);
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
