using UnityEngine;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// ��������{�^���̃I�u�W�F�N�g���܂Ƃ߂ĊǗ�����N���X
    /// �{�^���̐e�I�u�W�F�N�g�ɃA�^�b�`����z��
    /// </summary>
    public class InputButtonController : MonoBehaviour
    {
        //�I�����Ă�ꏊ��������摜��L���ɂ��邩���Ȃ����̃t���O
        [SerializeField]
        private bool                activateSelect = true;
        //�{�^�����삪���������c�������ݒ肷��t���O
        [SerializeField]
        private bool                horizontal;
        //�{�^�����������邩1�����Ȃ������肷��
        private bool                buttonIsArray = false;
        //�I�𒆂̉摜
        [SerializeField]
        private Image               selectImage;
        //�I�����Ă�v�f��
        private int                 selectIndex = 0;
        //�I�𒆂̉摜���{�^�����̂ǂꂭ�炢�̈ʒu�ɐݒu���邩
        [SerializeField]
        private float               selectImageOffsetX;
        //�q�I�u�W�F�N�g�Ƀ{�^��
        [SerializeField]
        private InputActionButton[] buttons;
        //SE�Đ��p�N���X
        private SEManager           seManager;

        private void Awake()
        {
            InputActionButton[] b = GetComponentsInChildren<InputActionButton>();
            buttons = b;
            seManager = GetComponent<SEManager>();
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
                    seManager.Play();
                }
                else if (action > 0)
                {
                    selectIndex++;
                    if (selectIndex >= buttons.Length)
                    {
                        selectIndex = buttons.Length - 1;
                    }
                    SetSelectImagePosition(selectIndex);
                    seManager.Play();
                }
            }

            if (InputUIAction.Instance.Deside)
            {
                buttons[selectIndex].OnButtonInput();
                seManager.Play(1);
            }
        }
    }
}
