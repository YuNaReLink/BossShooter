using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * 複数あるボタンのオブジェクトをまとめて管理するクラス
     * ボタンの親オブジェクトにアタッチする想定
     */
    public class InputButtonController : MonoBehaviour
    {
        //選択してる場所が分かる画像を有効にするかしないかのフラグ
        [SerializeField]
        private bool                activateSelect = true;
        //ボタン操作が横方向か縦方向か設定するフラグ
        [SerializeField]
        private bool                horizontal;
        //ボタンが複数あるか1つしかないか判定する
        private bool                buttonIsArray = false;
        //選択中の画像
        [SerializeField]
        private Image               selectImage;
        //選択してる要素数
        private int                 selectIndex = 0;
        //選択中の画像をボタン横のどれくらいの位置に設置するか
        [SerializeField]
        private float               selectImageOffsetX;
        //子オブジェクトにボタン
        [SerializeField]
        private InputActionButton[] buttons;
        //SE再生用クラス
        private SEHandler           seHandler;

        [SerializeField]
        private bool                buttonStop;

        private void Awake()
        {
            buttons = GetComponentsInChildren<InputActionButton>();
            seHandler = GetComponent<SEHandler>();
        }

        private void Start()
        {
            if(buttons.Length > 1)
            {
                buttonIsArray = true;
            }
            else
            {
                buttonIsArray = false;
            }
            selectIndex = 0;
            SetSelectImagePosition(selectIndex);
        }
        private void SetSelectImagePosition(int index)
        {
            if(!activateSelect||selectImage == null) { return; }
            Vector2 pos = buttons[index].RectTransform.anchoredPosition;
            pos.x -= selectImageOffsetX;
            selectImage.rectTransform.anchoredPosition = pos;
        }
        private void Update()
        {
            float select;
            if (horizontal)
            {
                select = InputUIAction.Instance.Select.x;
            }
            else
            {
                select = -InputUIAction.Instance.Select.y;
            }
            Input(select);
        }

        private void Input(float action)
        {
            if (buttonIsArray)
            {
                if (action < 0)
                {
                    selectIndex--;
                    if (selectIndex < 0)
                    {
                        selectIndex = 0;
                    }
                    SetSelectImagePosition(selectIndex);
                    seHandler.Play((int)ButtonSETag.Select);
                }
                else if (action > 0)
                {
                    selectIndex++;
                    if (selectIndex >= buttons.Length)
                    {
                        selectIndex = buttons.Length - 1;
                    }
                    SetSelectImagePosition(selectIndex);
                    seHandler.Play((int)ButtonSETag.Select);
                }
            }

            if (InputUIAction.Instance.Decide)
            {
                buttons[selectIndex].OnButtonInput();
                seHandler.Play((int)ButtonSETag.Decide);
            }
        }
    }
}
