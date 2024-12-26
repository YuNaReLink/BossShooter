using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// 複数あるボタンのオブジェクトをまとめて管理するクラス
    /// ボタンの親オブジェクトにアタッチする想定
    /// </summary>
    public class InputButtons : MonoBehaviour
    {

        //選択してる場所が分かる画像を有効にするかしないかのフラグ
        [SerializeField]
        private bool activateSelect = true;

        [SerializeField]
        private Image selectImage;

        private int selectIndex = 0;

        [SerializeField]
        private InputActionButton[] buttons;

        private void Awake()
        {

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
            if(!activateSelect||selectImage == null) { return; }
            Vector2 pos = buttons[index].RectTransform.anchoredPosition;
            pos.x -= 300f;
            selectImage.rectTransform.anchoredPosition = pos;
        }
        private void Update()
        {
            if(InputUIAction.Instance.Select.x < 0)
            {
                selectIndex--;
                if(selectIndex < 0)
                {
                    selectIndex = 0;
                }
                SetSelectImagePosition(selectIndex);
            }
            else if(InputUIAction.Instance.Select.x > 0)
            {
                selectIndex++;
                if(selectIndex >= buttons.Length)
                {
                    selectIndex = buttons.Length - 1;
                }
                SetSelectImagePosition(selectIndex);
            }

            if (InputUIAction.Instance.Deside)
            {
                buttons[selectIndex].OnButtonInput();
            }
        }
    }
}
