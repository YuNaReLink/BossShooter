using System;

namespace CreateScript
{
    /*
     * �S�N���X�Ő������ċ��ʂŎg����^�C�}�[�N���X
     */
    [System.Serializable]
    public class Timer
    {
        //�^�C�}�[���I��������Ɉ�x�������s������Action
        public event Action     OnEnd;
        //�^�C�}�[�I�����ɉ���ł��Ăяo�����Action
        public event Action     OnOnceEnd;
        //���݂̃J�E���g��ێ�����ϐ�
        private float current = 0;
        //���[�v���Ɏg���ϐ�
        private float time = 0;
        //�I�����̃J�E���g
        private float endTime = 0;

        public float Current => current;
        //�^�C�}�[�����[�v�����邩�̃t���O
        private bool loop = false;
        public void SetLoop(bool l) { loop = l; }
        //�^�C�}�[���X�^�[�g������֐�
        public void Start(float _time)
        {
            current = _time;
            time = _time;
        }
        //�^�C�}�[�̃J�E���g��ǉ�����֐�
        public void AddCurrent(float _time)
        {
            current += _time;
        }
        //�^�C�}�[�̍X�V����
        public void Update(float t)
        {
            if (current <= endTime) { return; }
            current -= t;
            if (current <= endTime)
            {
                if (loop)
                {
                    current += time;
                }
                End();
            }
        }
        //�^�C�}�[���I��������ɍs������
        public void End()
        {
            OnEnd?.Invoke();
            OnOnceEnd?.Invoke();
            OnOnceEnd = null;
        }
        //�^�C�}�[���I��������ǂ����𔻒�
        public bool IsEnd() { return current <= endTime; }
    }

}
