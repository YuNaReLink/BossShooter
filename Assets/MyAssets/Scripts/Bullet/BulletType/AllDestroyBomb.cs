using UnityEngine;

namespace CreateScript
{
    /*
     * “G‚Ì’e‚ð‘S‚Ä”j‰ó‚·‚éƒ{ƒ€–{‘Ì‚ÌƒNƒ‰ƒX
     */
    public class AllDestroyBomb : BaseBullet
    {
        private Vector2                 direction = Vector2.zero;

        private Timer                   explosionTimer = new Timer();

        [SerializeField]
        private float                   explosionCount;

        protected override BulletType   BulletType => BulletType.Bomb;
        private void Start()
        {
            rigidbody2D.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);

            explosionTimer.Start(explosionCount);
            explosionTimer.OnEnd += Explosion;
        }

        private void Update()
        {
            explosionTimer.Update(Time.deltaTime);
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }

        private void Explosion()
        {
            Erase(transform.position);
        }

        protected override void Erase(Vector2 pos)
        {
            GameController.Instance.DecreaseBombCount();
            BaseBullet[] baseBullets = FindObjectsOfType<BaseBullet>();
            foreach (BaseBullet bullet in baseBullets)
            {
                if (bullet.ShooterType == ShopterType.Enemy)
                {
                    bullet.AddScore();
                    Instantiate(effect.gameObject, bullet.transform.position, Quaternion.identity);
                    Destroy(bullet.gameObject);
                }
            }
            base.Erase(pos);
        }
    }
}
