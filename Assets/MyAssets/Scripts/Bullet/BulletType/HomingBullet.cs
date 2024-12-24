using UnityEngine;

namespace CreateScript
{
    public class HomingBullet : BaseBullet
    {
        //�e�̐������x
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

        // �U���\�Ȋp�x�i�x���@�j
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
            //�e����ǂ�������Ώۂւ̕������v�Z
            Vector3 vector3 = targetTransform.position - transform.position;
            //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����
            rigidbody2D.AddForce(vector3.normalized * bulletSpeed);

            //X�����̑��x�𐧌�
            float speedXTemp = Mathf.Clamp(rigidbody2D.velocity.x, -limitSpeed, limitSpeed);
            //Y�����̑��x�𐧌�
            float speedYTemp = Mathf.Clamp(rigidbody2D.velocity.y, -limitSpeed, limitSpeed);
            //���ۂɐ��������l����
            rigidbody2D.velocity = new Vector3(speedXTemp, speedYTemp);

            bulletImage.SetRotation(rigidbody2D);
        }

        private bool NoHomingAngle()
        {
            Vector2 currentVelocity = rigidbody2D.velocity.normalized;
            // �^�[�Q�b�g�ւ̕������v�Z
            Vector2 toTarget = (targetTransform.position - transform.position).normalized;

            // ���ς��v�Z
            float dot = Vector2.Dot(currentVelocity, toTarget);

            // �U���\�p�x�̓��ς�臒l���v�Z
            float angleLimitCos = Mathf.Cos(homingAngleLimit * Mathf.Deg2Rad);
            
            if(dot >= angleLimitCos)
            {
                return false;
            }

            return true;
        }
    }
}
