using UnityEngine;

namespace CreateScript
{
    /*
     * ƒ‰ƒ“ƒ_ƒ€‚È•ûŒü‚É”ò‚Î‚·’e‚ÌƒNƒ‰ƒX
     * Œ»ó‚Í‚Ü‚Á‚·‚®”ò‚Ô’e‚Æ‚Ù‚Ú“¯‚¶
     */
    public class RandomBullet : BaseBullet
    {
        private Vector2 direction = Vector2.zero;

        public override BulletType BulletType => BulletType.Random;
        private void Start()
        {
            rigidbody2D.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);
        }
        //”ò‚Ô•ûŒü‚ðŒˆ’è
        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
