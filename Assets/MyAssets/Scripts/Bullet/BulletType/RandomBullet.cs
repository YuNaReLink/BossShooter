using UnityEngine;

namespace CreateScript
{
    /*
     * �����_���ȕ����ɔ�΂��e�̃N���X
     * ����͂܂�������Ԓe�Ƃقړ���
     */
    public class RandomBullet : BaseBullet
    {
        private Vector2 direction = Vector2.zero;

        public override BulletType BulletType => BulletType.Random;
        private void Start()
        {
            rigidbody2D.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            bulletImage.SetRotation(rigidbody2D);
        }
        //��ԕ���������
        public void SetDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
