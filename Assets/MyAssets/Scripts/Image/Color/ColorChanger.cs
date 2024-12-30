using UnityEngine;

namespace CreateScript
{
    public class ColorChanger : MonoBehaviour
    {
        //�J���[�ύX���L�����̃t���O
        [SerializeField]
        private bool            active;
        //�ύX���鎞��
        [SerializeField]
        private float           changeCount;
        //�ύX���ǂꂭ�炢�̊Ԋu�ŐF��؂�ւ��邩�̎���
        [SerializeField]
        private float           loopCount;
        //�ύX��̃J���[
        [SerializeField]
        private Color           changeColor;
        //�ύX�O�̃J���[
        private Color           baseColor;

        //�J���[��ύX����^�C�}�[
        private Timer           changeTimer = new();
        //�J���[��_�ł�����Ԋu���Ǘ�����^�C�}�[
        private Timer           loopTimer = new();

        private SpriteRenderer  spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            baseColor = spriteRenderer.color;

            changeTimer.OnEnd += Finsh;

            loopTimer.SetLoop(true);
            loopTimer.OnEnd += Toggle;

            active = false;
        }
        public void Update()
        {
            if (changeTimer.IsEnd())
            {
                return;
            }
            float t = Time.deltaTime;
            loopTimer.Update(t);
            changeTimer.Update(t);
        }

        //�F��ύX��������
        public void ColorChangeStart()
        {
            changeTimer.Start(changeCount);
            loopTimer.Start(loopCount);
        }
        //�펞�F��ύX������������
        public void LoopColorChangeStart()
        {
            changeTimer.Start(changeCount);
        }

        //���[�v���̎�
        public void Toggle()
        {
            SetState(!active);
        }
        //�I�������
        public void Finsh()
        {
            SetState(false);
        }
        //�t���O�Ō��̐F���ύX��̐F�ɕς���
        private void SetState(bool b)
        {
            active = b;
            spriteRenderer.color = b ? changeColor : baseColor;
        }
    }
}
