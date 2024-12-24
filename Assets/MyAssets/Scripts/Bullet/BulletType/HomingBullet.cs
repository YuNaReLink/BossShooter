using UnityEngine;

namespace CreateScript
{
    public class HomingBullet : BaseBullet
    {
        //’e‚Ì§ŒÀ‘¬“x
        [SerializeField] 
        private float       limitSpeed;

        private Transform   targetTransform;
        public void SetHomingTarget(Transform t)
        {
            targetTransform = t;
            timer.Start(homingCount);
        }

        private Timer       timer = new();

        [SerializeField]
        private float       homingCount = 5.0f;

        // —U“±‰Â”\‚ÈŠp“xi“x”–@j
        [SerializeField]
        private float       homingAngleLimit = 30f;

        protected override BulletType BulletType => BulletType.Homing;
        private void Start()
        {
            Homing();
        }

        private void Update()
        {
            timer.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (timer.IsEnd()) { return; }

            if(targetTransform == null) { return; }
            if (NoHomingAngle()) { return; }


            Homing();
        }

        private void Homing()
        {
            //’e‚©‚ç’Ç‚¢‚©‚¯‚é‘ÎÛ‚Ö‚Ì•ûŒü‚ğŒvZ
            Vector3 vector3 = targetTransform.position - transform.position;
            //•ûŒü‚Ì’·‚³‚ğ1‚É³‹K‰»A”CˆÓ‚Ì—Í‚ğAddForce‚Å‰Á‚¦‚é
            rigidbody2D.AddForce(vector3.normalized * bulletSpeed);

            //X•ûŒü‚Ì‘¬“x‚ğ§ŒÀ
            float speedXTemp = Mathf.Clamp(rigidbody2D.velocity.x, -limitSpeed, limitSpeed);
            //Y•ûŒü‚Ì‘¬“x‚ğ§ŒÀ
            float speedYTemp = Mathf.Clamp(rigidbody2D.velocity.y, -limitSpeed, limitSpeed);
            //ÀÛ‚É§ŒÀ‚µ‚½’l‚ğ‘ã“ü
            rigidbody2D.velocity = new Vector3(speedXTemp, speedYTemp);

            bulletImage.SetRotation(rigidbody2D);
        }

        private bool NoHomingAngle()
        {
            Vector2 currentVelocity = rigidbody2D.velocity.normalized;
            // ƒ^[ƒQƒbƒg‚Ö‚Ì•ûŒü‚ğŒvZ
            Vector2 toTarget = (targetTransform.position - transform.position).normalized;

            // “àÏ‚ğŒvZ
            float dot = Vector2.Dot(currentVelocity, toTarget);

            // —U“±‰Â”\Šp“x‚Ì“àÏ‚Ìè‡’l‚ğŒvZ
            float angleLimitCos = Mathf.Cos(homingAngleLimit * Mathf.Deg2Rad);
            
            if(dot >= angleLimitCos)
            {
                return false;
            }

            return true;
        }
    }
}
