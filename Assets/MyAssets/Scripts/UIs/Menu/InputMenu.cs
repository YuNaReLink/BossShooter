using UnityEngine;

namespace CreateScript
{
    /*
     * ���j���[�̊J���͂��s���N���X
     */
    public class InputMenu : MonoBehaviour
    {
        private bool open;


        private MenuCaller caller;

        private void Awake()
        {
            caller = GetComponent<MenuCaller>();
        }

        private void Start()
        {
            open = false;
            caller.Close();
        }

        //���j���[�̍X�V
        private void Update()
        {
            if (!InputUIAction.Instance.Pause) { return; }
            open = !open;

            //�t���O����ĊJ�����߂�
            if (open)
            {
                caller.Call();
            }
            else
            {
                caller.Close();
            }
        }
    }
}
