using UnityEngine;

namespace CreateScript
{
    [System.Serializable]
    public class FireBomb : IFireBullet
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
            GameObject g = GameObject.Instantiate(bulletData.Bullets[(int)PlayerBulletType.Bomb].gameObject, transform.position, Quaternion.identity);
            AllDestroyBomb bomb = g.GetComponent<AllDestroyBomb>();
            if (bomb != null)
            {
                bomb.SetExeclude(transform.gameObject.layer);
                bomb.SetShooterType(ShopterType.Player);
                bomb.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
