using UnityEngine;

namespace CreateScript
{
    /*
     * �^�[�Q�b�g�Ɍ������Ĕ�Ԓe�{�̂̃N���X
     */
    public class LockOnBullet : BaseBullet
    {

        private Vector2                 direction = Vector2.zero;

        private Transform               target;

        public override BulletType   BulletType => BulletType.LockOn;

        //Start���Ƀ^�[�Q�b�g�Ǝ����̍��W���g���ă^�[�Q�b�g�܂Ŕ�΂��������s��
        private void Start()
        {
            direction = target.position - transform.position;
            rigidbody2D.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);
        }
        //�^�[�Q�b�g��ݒ�
        public void SetPlayerTransform(Transform transform)
        {
            target = transform;
        }
        //������ݒ�
        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
