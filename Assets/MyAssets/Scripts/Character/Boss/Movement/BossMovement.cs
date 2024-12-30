using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �{�X�̈ړ������N���X
    /// </summary>
    [System.Serializable]
    public class BossMovement
    {
        //�{�X�̃g�����X�t�H�[��
        private Transform   transform;
        //�X�s�[�h
        [SerializeField]
        private float       speed = 2f;
        //�㉺�Ɉړ����邽�߂̃t���O
        [SerializeField]
        private bool        reverse = false;
        //��ʂ̏㉺�łǂ��܂ł̍����܂ōs�����𐧌����鐔�l
        [SerializeField]
        private float       height = 1f;
        //��Ԃ��ς�������ɃX�s�[�h��ύX���鏈��
        public void SetSpeed(float s)
        {
            speed = s;
        }
        //Awake���ɏ���
        public void Setup(BossSetup actor)
        {
            transform = actor.GameObject.transform;
        }

        public void DoStart()
        {
            reverse = false;
        }
        //�㉺�Ɉړ����鏈��
        public void VerticalMove()
        {
            Vector2 pos = transform.position;
            int dir = reverse ? -1 : 1;
            pos.y += speed * dir * Time.deltaTime;
            transform.position = pos;
            Camera camera = Camera.main;
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
            if (screenBounds.y - height < transform.position.y)
            {
                reverse = true;
            }
            else if (-screenBounds.y + height > transform.position.y)
            {
                reverse = false;
            }
        }
    }
}
