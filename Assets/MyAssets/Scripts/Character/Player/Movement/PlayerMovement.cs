using UnityEngine;

namespace CreateScript
{
    /*
     * �v���C���[�̈ړ��������s���N���X
     */
    [System.Serializable]
    public class PlayerMovement
    {
        //�v���C���[�̃g�����X�t�H�[��
        private Transform   transform;
        //�v���C���[�̓���
        private PlayerInput Input;
        //�X�s�[�h
        [SerializeField]
        private float       speed = 5f;
        //PlayerController��Awake���ɏ���
        public void Setup(PlayerSetup actor)
        {
            transform = actor.GameObject.transform;
            Input = actor.Input;
        }
        //�ړ�����
        public void Move()
        {
            Vector3 pos = transform.position;
            float s = speed;
            if (Input.SpeedDown > 0)
            {
                s *= Input.SpeedDown;
            }
            pos.x += s * Input.Horizontal * Time.deltaTime;
            pos.y += s * Input.Vertical * Time.deltaTime;
            transform.position = pos;
        }
    }
}
