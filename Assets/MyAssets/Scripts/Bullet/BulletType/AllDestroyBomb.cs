using UnityEngine;

namespace CreateScript
{
    /*
     * �G�̒e��S�Ĕj�󂷂�{���{�̂̃N���X
     */
    public class AllDestroyBomb : BaseBullet
    {
        private Vector2                 direction = Vector2.zero;

        private Timer                   explosionTimer = new Timer();
        //��������܂ł̃J�E���g
        [SerializeField]
        private float                   explosionCount;

        public override BulletType   BulletType => BulletType.Bomb;
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
        //�����������ɃQ�[���ɑ��݂���G�̒e�����ׂč폜���鏈��
        protected override void Erase(Vector2 pos)
        {
            GameController.Instance.DecreaseBombCount();
            BaseBullet[] baseBullets = FindObjectsOfType<BaseBullet>();
            foreach (BaseBullet bullet in baseBullets)
            {
                if (bullet.ShooterType == ShopterType.Enemy)
                {
                    //���������ɒe�ʂɃX�R�A�����Z
                    ScoreSystem.Instance.AddScore(bullet.BulletType);
                    //�G�t�F�N�g����
                    effectManager.Create(bullet.transform.position, transform.localScale * effectScaleRatio);
                    Destroy(bullet.gameObject);
                }
            }
            base.Erase(pos);
        }
    }
}
