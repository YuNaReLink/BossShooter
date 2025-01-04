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

        private float current = 0;

        private float time = 0;

        private float endTime = 0;

        public float Current => current;

        private bool loop = false;
        public void SetLoop(bool l) { loop = l; }

        public void Start(float _time)
        {
            current = _time;
            time = _time;
        }

        public void AddCurrent(float _time)
        {
            current += _time;
        }

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

        public void End()
        {
            OnEnd?.Invoke();
            OnOnceEnd?.Invoke();
            OnOnceEnd = null;
        }

        public bool IsEnd() { return current <= endTime; }
    }

}
