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
        //*選択入力関係*//
        private InputAction             SelectAction;
        [SerializeField]
        private Vector2                 select;
        public Vector2                  Select => select;
        //*決定入力関係*//
        private InputAction             desideAction;
        [SerializeField]
        private bool                    deside;
        public bool                     Deside => deside;
        //*ポーズ入力関係*//
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
