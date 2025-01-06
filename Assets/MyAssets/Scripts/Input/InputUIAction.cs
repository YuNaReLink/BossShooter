using UnityEngine;
using UnityEngine.InputSystem;

namespace CreateScript
{
    /*
     * UIのボタン入力を管理するクラス
     * シングルトンパターンでどこらでもアクセスが可能
     */
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
        private InputAction             decideAction;
        [SerializeField]
        private bool                    decide;
        public bool                     Decide => decide;
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

        /*
         * ボタン入力だとコルーチンではただしく押した瞬間を判定出来なかったので
         * Update内で判定
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
