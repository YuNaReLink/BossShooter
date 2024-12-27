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

        private InputAction             SelectAction;

        private Vector2                 select;
        public Vector2                  Select => select;

        private InputAction             desideAction;

        private bool                    deside;
        public bool                     Deside => deside;

        private InputAction             pauseAciton;

        private bool                    pause;
        public bool                     Pause => pause;

        private void Awake()
        {
            instance = this;

            inputActions = new InputActionsControls();
        }

        private void OnVectorKey(InputAction.CallbackContext context)
        {
            select = inputActions.UI.Select.ReadValue<Vector2>();
            // ��u����true�ɂ��āA���̃t���[����false�ɖ߂�
            StartCoroutine(VectorKeyPress());
        }
        private System.Collections.IEnumerator VectorKeyPress()
        {
            yield return null; // 1�t���[���҂�
            select = Vector2.zero;
        }

        private void OnDeside(InputAction.CallbackContext context)
        {
            deside = true;
            // ��u����true�ɂ��āA���̃t���[����false�ɖ߂�
            StartCoroutine(DesidePress());
        }
        private System.Collections.IEnumerator DesidePress()
        {
            yield return null; // 1�t���[���҂�
            deside = false;
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

            SelectAction.performed += OnVectorKey;

            SelectAction.Enable();

            desideAction = inputActions.UI.Deside;

            desideAction.performed += OnDeside;

            desideAction.Enable();

            pauseAciton = inputActions.UI.Pause;

            pauseAciton.performed += OnPause;

            pauseAciton.Enable();
        }

        private void OnDisable()
        {
            SelectAction.performed -= OnVectorKey;

            SelectAction.Disable();

            desideAction.performed -= OnDeside;

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
