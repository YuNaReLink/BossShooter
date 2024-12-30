using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �^�[�Q�b�g�Ɍ������Ĕ�Ԓe�{�̂̃N���X
    /// </summary>
    public class LockOnBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        private Transform               playerTransform;

        protected override BulletType   BulletType => BulletType.LockOn;

        //Start���Ƀ^�[�Q�b�g�Ǝ����̍��W���g���ă^�[�Q�b�g�܂Ŕ�΂��������s��
        private void Start()
        {
            direction = playerTransform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(GetComponent<Rigidbody2D>());
        }
        //�^�[�Q�b�g��ݒ�
        public void SetPlayerTransform(Transform transform)
        {
            playerTransform = transform;
        }
        //������ݒ�
        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
