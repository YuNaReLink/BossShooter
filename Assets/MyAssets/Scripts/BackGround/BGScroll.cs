using UnityEngine;

namespace CreateScript
{
    public class BGScroll : MonoBehaviour
    {
        //�w�i���X�N���[��������X�s�[�h
        [SerializeField] 
        private float scrollSpeed; 
        //�w�i�̃X�N���[�����J�n����ʒu
        [SerializeField] 
        private float startLine;
        //�w�i�̃X�N���[�����I������ʒu
        [SerializeField] 
        private float deadLine;

        [SerializeField]
        private float backGroundImageInterval = 19f;

        [SerializeField]
        private GameObject[] backGrounds = new GameObject[2];

        private void Start()
        {
            for(int i = 0; i < backGrounds.Length; i++)
            {
                backGrounds[i].transform.localPosition = new Vector3(i * backGroundImageInterval, 0, 0);
            }
        }

        void Update()
        {
            for(int i = 0;i < backGrounds.Length; i++)
            {
                Scroll(i);
            }
        }

        public void Scroll(int i)
        {
            float speed = scrollSpeed * Time.deltaTime;
            backGrounds[i].transform.Translate(speed, 0, 0); //x���W��scrollSpeed��������

            if (backGrounds[i].transform.position.x < deadLine) //�����w�i��x���W���deadLine���傫���Ȃ�����
            {
                backGrounds[i].transform.localPosition = new Vector3(startLine, 0, 0);//�w�i��startLine�܂Ŗ߂�
            }
        }
    }
}