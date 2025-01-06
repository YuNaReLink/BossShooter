using UnityEngine;

namespace CreateScript
{
    /*
     * w’è‚µ‚½•ûŒü‚É^‚Á‚·‚®”ò‚Ô’e‚ğ"”­Ë"‚·‚éˆ—‚ğs‚¤ƒNƒ‰ƒX
     */
    [System.Serializable]
    public class FireStraightBullet : IFireBullet
    {
        private Transform       transform;

        private Timer           timer = new Timer();

        //’e‚Ìƒf[ƒ^
        private OffScreenObject bullet;

        private SEHandler       seHandler;
        //”­ËŠÔŠu‚Ì”’l
        [SerializeField]
        private float           fireCoolDownCount = 0.1f;
        //’e”­ËŠÔŠu‚ÌÅ’áŠÔŠu
        public float            MinFireCount => 0.25f;
        [SerializeField]
        private Vector2         direction = Vector2.zero;


        //”­ËŠÔŠu‚ğŒ¸‚ç‚·ˆ—
        public void DecreaseFireCountCoolDown(float count)
        {
            fireCoolDownCount -= count;
            if(fireCoolDownCount <= MinFireCount)
            {
                fireCoolDownCount = MinFireCount;
            }
        }


        public void Setup(IBaseLaunch launch)
        {
            transform = launch.GameObject.transform;
            bullet = launch.BulletData[(int)PlayerBulletType.Straight];
            seHandler = launch.SEHandler;
        }

        public void DoUpdate(float time)
        {
            timer.Update(Time.deltaTime);
        }
        //’e”­Ëˆ—
        public void Fire(Transform target)
        {
            if (!timer.IsEnd()) { return; }
            GameObject g = GameObject.Instantiate(bullet.gameObject, transform.position,Quaternion.identity);
            StraightBullet straightBullet = g.GetComponent<StraightBullet>();
            if(straightBullet != null)
            {
                //’e”­Ë‚É•K—v‚Èˆ—‚ğs‚¤
                straightBullet.SetExeclude(transform.gameObject.layer);
                straightBullet.SetShooterType(ShopterType.Player);
                straightBullet.SetDirection(direction);
            }
            timer.Start(fireCoolDownCount);
            seHandler.Play();
        }
    }
}
