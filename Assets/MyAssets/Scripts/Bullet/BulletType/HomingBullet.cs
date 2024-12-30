using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ホーミング弾本体の処理を行うクラス
    /// </summary>
    public class HomingBullet : BaseBullet
    {
        //弾の制限速度
        [SerializeField] 
        private float                   limitSpeed;

        private Transform               targetTransform;

        private Timer                   timer = new();
        //誘導が切れるカウント
        [SerializeField]
        private float                   homingCount = 5.0f;

        // 誘導可能な角度（度数法）
        [SerializeField]
        private float                   homingAngleLimit = 30f;

        protected override BulletType   BulletType => BulletType.Homing;
        //発射時にスピードを1.0f～2.0fの間でランダムに決める処理
        public void SetHomingTarget(Transform t)
        {
            targetTransform = t;
            timer.Start(homingCount);
            float raito = Random.Range(1.0f, 2.1f);
            bulletSpeed *= raito;
            limitSpeed *= raito;
        }
        private void Start()
        {
            timer.OnEnd += TimerEndAddPower;
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
        //ホーミング中の処理
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
        //誘導可能かを判定するメソッド
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
        //タイマーが終わった時に進んでいる方向にスピード分力を加える
        private void TimerEndAddPower()
        {
            rigidbody2D.AddForce(rigidbody2D.velocity * bulletSpeed);
        }
    }
}
