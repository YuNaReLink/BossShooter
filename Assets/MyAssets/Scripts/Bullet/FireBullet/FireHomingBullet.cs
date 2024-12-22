using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateScript
{
    [System.Serializable]
    public class FireHomingBullet : IFireBullet
    {
        private Transform transform;

        private Timer timer = new Timer();

        [SerializeField]
        private BulletData bulletData;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;

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
            GameObject g = GameObject.Instantiate(bulletData.Bullets[(int)EnemyBulletType.Homing].gameObject, transform.position, Quaternion.identity);
            HomingBullet homingBullet = g.GetComponent<HomingBullet>();
            if (homingBullet != null)
            {
                homingBullet.SetShooterType(ShopterType.Enemy);
                homingBullet.SetExeclude(transform.gameObject.layer);
                homingBullet.SetHomingTarget(target);
            }
            timer.Start(fireCoolDownCount);
        }
    }
}
