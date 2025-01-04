using UnityEngine;

namespace CreateScript
{
    /*
     * �e�̉摜�I�u�W�F�N�g�ɃA�^�b�`�������
     * Bullet�N���X�Ŏw�肳��Ă����������
     * �I�u�W�F�N�g�̌�����ύX���鏈��
     */
    public class BulletImage : MonoBehaviour
    {
        public void SetRotation(Rigidbody2D rigidbody2D)
        {
            // �ړ������i���x�x�N�g���j���擾
            Vector2 velocity = rigidbody2D.velocity;

            // ���x���\���������ꍇ�͉�]���ێ�
            if (velocity.sqrMagnitude < 0.01f)
            {
                return;
            }

            // �����x�N�g������p�x���v�Z (���W�A����x�ɕϊ�)
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

            // �ΏۃI�u�W�F�N�g����]
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
