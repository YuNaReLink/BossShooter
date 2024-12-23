using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CreateScript
{
    public class InputButtons : MonoBehaviour
    {
        private InputActionsControls inputActions;

        [SerializeField]
        private Image selectImage;

        [SerializeField]
        private InputActionButton[] buttons;

        private InputAction SelectAction;

        private Vector2 select;

        private int selectIndex = 0;

        private InputAction desideAction;

        private bool deside;


        private void Awake()
        {
            inputActions = new InputActionsControls();

            InputActionButton[] b = GetComponentsInChildren<InputActionButton>();
            buttons = b;
        }

        private void Start()
        {
            selectIndex = 0;
            SetSelectImagePosition(selectIndex);
        }
        private void SetSelectImagePosition(int index)
        {
            Vector2 pos = buttons[index].RectTransform.anchoredPosition;
            pos.x -= 300f;
            selectImage.rectTransform.anchoredPosition = pos;
        }
        private void Update()
        {
            if(select.x < 0)
            {
                selectIndex = 0;
                SetSelectImagePosition(0);
            }
            else if(select.x > 0)
            {
                selectIndex = 1;
                SetSelectImagePosition(1);
            }

            if (deside)
            {
                buttons[selectIndex].OnInputButton();
            }
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

        private void OnEnable()
        {
            inputActions.Enable();

            SelectAction = inputActions.UI.Select;

            SelectAction.performed += OnVectorKey;

            SelectAction.Enable();

            desideAction = inputActions.UI.Deside;

            desideAction.performed += OnDeside;

            desideAction.Enable();
        }

        private void OnDisable()
        {
            SelectAction.performed -= OnVectorKey;

            SelectAction.Disable();

            desideAction.performed -= OnDeside;

            desideAction.Disable();

            inputActions.Disable();
        }

        private void OnDestroy()
        {
            inputActions.Dispose();
        }
    }
}
