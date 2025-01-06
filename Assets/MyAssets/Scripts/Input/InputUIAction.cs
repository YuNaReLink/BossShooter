using UnityEngine;
using UnityEngine.InputSystem;

namespace CreateScript
{
    /*
     * UI�̃{�^�����͂��Ǘ�����N���X
     * �V���O���g���p�^�[���łǂ���ł��A�N�Z�X���\
     */
    public class InputUIAction : MonoBehaviour
    {

        private static InputUIAction    instance;
        public static InputUIAction     Instance => instance;

        private InputActionsControls    inputActions;
        //*�I����͊֌W*//
        private InputAction             SelectAction;
        [SerializeField]
        private Vector2                 select;
        public Vector2                  Select => select;
        //*������͊֌W*//
        private InputAction             decideAction;
        [SerializeField]
        private bool                    decide;
        public bool                     Decide => decide;
        //*�|�[�Y���͊֌W*//
        private InputAction             pauseAciton;
        [SerializeField]
        private bool                    pause;
        public bool                     Pause => pause;

        private void Awake()
        {
            instance = this;

            inputActions = new InputActionsControls();
        }

        /*
         * �{�^�����͂��ƃR���[�`���ł͂��������������u�Ԃ𔻒�o���Ȃ������̂�
         * Update���Ŕ���
         */
        private void Update()
        {
            if (SelectAction.IsPressed())
            {
                select = Vector2.zero;
            }
            if (SelectAction.WasPressedThisFrame())
            {
                select = inputActions.UI.Select.ReadValue<Vector2>();
            }
            if (SelectAction.WasReleasedThisFrame())
            {
                select = Vector2.zero;
            }

            if (decideAction.IsPressed())
            {
                decide = false;
            }
            if (decideAction.WasPressedThisFrame())
            {
                decide = true;
            }
            if (decideAction.WasReleasedThisFrame())
            {
                decide = false;
            }

            if (pauseAciton.IsPressed())
            {
                pause = false;
            }
            if (pauseAciton.WasPressedThisFrame())
            {
                pause = true;
            }
            if (pauseAciton.WasReleasedThisFrame())
            {
                pause = false;
            }
        }

        private void OnEnable()
        {
            inputActions.Enable();

            SelectAction = inputActions.UI.Select;

            SelectAction.Enable();

            decideAction = inputActions.UI.Decide;

            decideAction.Enable();

            pauseAciton = inputActions.UI.Pause;

            pauseAciton.Enable();
        }

        private void OnDisable()
        {

            SelectAction.Disable();

            decideAction.Disable();

            pauseAciton.Disable();

            inputActions.Disable();
        }

        private void OnDestroy()
        {
            inputActions.Dispose();
        }
    }
}
