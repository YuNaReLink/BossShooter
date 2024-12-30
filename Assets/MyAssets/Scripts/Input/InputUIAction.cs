using UnityEngine;
using UnityEngine.InputSystem;

namespace CreateScript
{
    /// <summary>
    /// UI�̃{�^�����͂��Ǘ�����N���X
    /// �V���O���g���p�^�[���łǂ���ł��A�N�Z�X���\
    /// </summary>
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
        private InputAction             desideAction;
        [SerializeField]
        private bool                    deside;
        public bool                     Deside => deside;
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

            if (desideAction.IsPressed())
            {
                deside = false;
            }
            if (desideAction.WasPressedThisFrame())
            {
                deside = true;
            }
        }
        private void OnPause(InputAction.CallbackContext context)
        {
            pause = true;
            // ��u����true�ɂ��āA���̃t���[����false�ɖ߂�
            StartCoroutine(PausePress());
        }
        private System.Collections.IEnumerator PausePress()
        {
            yield return null; // 1�t���[���҂�
            pause = false;
        }

        private void OnEnable()
        {
            inputActions.Enable();

            SelectAction = inputActions.UI.Select;

            SelectAction.Enable();

            desideAction = inputActions.UI.Deside;

            desideAction.Enable();

            pauseAciton = inputActions.UI.Pause;

            pauseAciton.performed += OnPause;

            pauseAciton.Enable();
        }

        private void OnDisable()
        {

            SelectAction.Disable();

            desideAction.Disable();

            pauseAciton.performed -= OnPause;

            pauseAciton.Disable();

            inputActions.Disable();
        }

        private void OnDestroy()
        {
            inputActions.Dispose();
        }
    }
}
