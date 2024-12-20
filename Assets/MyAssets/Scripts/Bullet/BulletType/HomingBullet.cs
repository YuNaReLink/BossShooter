using UnityEngine;

namespace CreateScript
{
    public class HomingBullet : BaseBullet
    {
        //弾の制限速度
        [SerializeField] 
        private float limitSpeed;

        private Transform targetTransform;
        public void SetHomingTarget(Transform t)
        {
            targetTransform = t;
            timer.Start(homingCount);
        }

        private Timer timer = new();

        [SerializeField]
        private float homingCount = 5.0f;

        // 誘導可能な角度（度数法）
        [SerializeField]
        private float homingAngleLimit = 30f;

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
            //弾から追いかける対象への方向を計算
            Vector3 vector3 = targetTransform.position - transform.position;
            //方向の長さを1に正規化、任意の力をAddForceで加える
            rigidbody2D.AddForce(vector3.normalized * bulletSpeed);

            //X方向の速度を制限
            float speedXTemp = Mathf.Clamp(rigidbody2D.velocity.x, -limitSpeed, limitSpeed);
            //Y方向の速度を制限
            float speedYTemp = Mathf.Clamp(rigidbody2D.velocity.y, -limitSpeed, limitSpeed);
            //実際に制限した値を代入
            rigidbody2D.velocity = new Vector3(speedXTemp, speedYTemp);

            bulletImage.SetRotation(rigidbody2D);
        }

        private bool NoHomingAngle()
        {
            Vector2 currentVelocity = rigidbody2D.velocity.normalized;
            // ターゲットへの方向を計算
            Vector2 toTarget = (targetTransform.position - transform.position).normalized;

            // 内積を計算
            float dot = Vector2.Dot(currentVelocity, toTarget);

            // 誘導可能角度の内積の閾値を計算
            float angleLimitCos = Mathf.Cos(homingAngleLimit * Mathf.Deg2Rad);
            
            if(dot >= angleLimitCos)
            {
                return false;
            }

            return true;
        }
    }
}
