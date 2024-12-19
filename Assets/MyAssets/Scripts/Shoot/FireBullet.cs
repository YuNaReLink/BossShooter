using UnityEngine;

namespace CreateScript
{
    public class FireBullet : MonoBehaviour
    {
        private Timer timer = new Timer();

        [SerializeField]
        private Bullet bullet;

        [SerializeField]
        private float bulletSpeed = 0.5f;

        [SerializeField]
        private float fireCoolDownCount = 0.1f;

        private void Update()
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire()
        {
            if (!timer.IsEnd()) { return; }
            GameObject b = Instantiate(bullet.gameObject, transform.position,Quaternion.identity);
            Rigidbody2D rigidbody2D = b.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(Vector2.right * bulletSpeed,ForceMode2D.Impulse);
            timer.Start(fireCoolDownCount);
        }
    }
}
