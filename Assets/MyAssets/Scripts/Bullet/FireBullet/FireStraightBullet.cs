using UnityEngine;

namespace CreateScript
{
    /*
     * Žw’è‚µ‚½•ûŒü‚É^‚Á‚·‚®”ò‚Ô’e‚ð"”­ŽË"‚·‚éˆ—‚ðs‚¤ƒNƒ‰ƒX
     */
    [System.Serializable]
    public class FireStraightBullet : IFireBullet
    {
        private Transform   transform;

        private Timer       timer = new Timer();

        //’e‚Ìƒf[ƒ^
        private OffScreenObject bullet;

        private SEManager   seManager;
        //”­ŽËŠÔŠu‚Ì”’l
        [SerializeField]
        private float       fireCoolDownCount = 0.1f;
        //’e”­ŽËŠÔŠu‚ÌÅ’áŠÔŠu
        public float        MinFireCount => 0.25f;
        public void DecreaseFireCountCoolDown(float count)
        {
            fireCoolDownCount -= count;
            if(fireCoolDownCount <= MinFireCount)
            {
                fireCoolDownCount = MinFireCount;
            }
        }

        [SerializeField]
        private Vector2 direction = Vector2.zero;

        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)PlayerBulletType.Straight];
            seManager = launch.SEManager;
        }

        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }

        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position,Quaternion.identity);
            StraightBullet straightBullet = g.GetComponent<StraightBullet>();
            if(straightBullet != null)
            {
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Player);
                straightBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
            seManager.Play();
        }
    }
}
