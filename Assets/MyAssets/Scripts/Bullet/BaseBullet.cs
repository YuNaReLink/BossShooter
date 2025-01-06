using UnityEngine;

namespace CreateScript
{
    /*
     * �e�̌���������߂邽�߂�enum
     */
    public enum ShopterType
    {
        Player,
        Enemy
    }
    /*
     * �e�̎�ނ����߂�^�O
     */
    public enum BulletType
    {
        Null = -1,
        Straight,
        LockOn,
        Random,
        Homing,
        Bomb
    }
    /*
     * �Q�[���ɓo�ꂷ��e���ׂĂ��p�����Ă�x�[�X�̃N���X
     * �S�e�ɋ��ʂ��鏈���A�ϐ��������Ă���
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(EffectHandler))]
    public class BaseBullet : MonoBehaviour
    {
        //�e�̃X�s�[�h
        [SerializeField]
        protected float                 bulletSpeed;
        //�G�t�F�N�g����
        [SerializeField]
        protected EffectHandler         effectManager;
        //�G�t�F�N�g�̃T�C�Y�̔䗦
        [SerializeField]
        protected float                 effectScaleRatio = 5f;
        
        protected new Rigidbody2D       rigidbody2D;
        //�e�̃C���[�W�N���X
        protected BulletImage           bulletImage;
        //�N���������̂������ʉ����邽�߂̐錾
        protected ShopterType           shooterType;
        public ShopterType              ShooterType => shooterType;
        //�e�̃^�C�v���L�^����ϐ�
        protected virtual BulletType    BulletType => BulletType.Null;
        //SE����
        protected SEHandler             seHandler;

        public void SetShooterType(ShopterType s)
        {
            shooterType = s;
        }

        protected virtual void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            bulletImage = GetComponentInChildren<BulletImage>();
            effectManager = GetComponent<EffectHandler>();
            seHandler = GetComponent<SEHandler>();
        }

        public void SetExeclude(int layer)
        {
            gameObject.layer = layer;
        }
        // �e�̓����蔻��
        protected void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterHit(collision);
            BulletHit(collision);
        }
        //�e���v���C���[���{�X�ɓ���������
        private void CharacterHit(Collider2D collision)
        {
            HP hp = collision.GetComponent<HP>();
            if (hp == null || collision.transform.gameObject.layer == gameObject.layer) { return; }
            Erase(collision.ClosestPoint(transform.position));
        }
        //�e���ʂ̒e�ɓ���������
        private void BulletHit(Collider2D collision)
        {
            OffScreenObject bullet = collision.GetComponent<OffScreenObject>();
            if (bullet == null || collision.transform.gameObject.layer == gameObject.layer) { return; }
            if(ShooterType == ShopterType.Player)
            {
                AddScore();
            }
            Erase(collision.ClosestPoint(transform.position));
        }
        //�e����������
        protected virtual void Erase(Vector2 pos)
        {
            Destroy(gameObject);
            effectManager.Create(pos, transform.localScale * effectScaleRatio, (int)EffectTag.Hit);
            seHandler.Play();
        }
        //�X�R�A�����Z
        //�e�̃^�C�v�ɂ���Ēl���ω�
        public void AddScore()
        {
            ScoreSystem.Instance.AddScore(BulletType);
        }
    }

}
