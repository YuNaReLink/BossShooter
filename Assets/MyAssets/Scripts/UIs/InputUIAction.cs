using UnityEngine;
using UnityEngine.InputSystem;

namespace CreateScript
{
    /// <summary>
    /// UIのボタン入力を管理するクラス
    /// シングルトンパターンでどこらでもアクセスが可能
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
            // 一瞬だけtrueにして、次のフレームでfalseに戻す
            StartCoroutine(VectorKeyPress());
        }
        private System.Collections.IEnumerator VectorKeyPress()
        {
            yield return null; // 1フレーム待つ
            select = Vector2.zero;
        }

        private void OnDeside(InputAction.CallbackContext context)
        {
            deside = true;
            // 一瞬だけtrueにして、次のフレームでfalseに戻す
            StartCoroutine(DesidePress());
        }
        private System.Collections.IEnumerator DesidePress()
        {
            yield return null; // 1フレーム待つ
            deside = false;
        }
        private void OnPause(InputAction.CallbackContext context)
        {
            pause = true;
            // 一瞬だけtrueにして、次のフレームでfalseに戻す
            StartCoroutine(PausePress());
        }
        private System.Collections.IEnumerator PausePress()
        {
            yield return null; // 1フレーム待つ
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
