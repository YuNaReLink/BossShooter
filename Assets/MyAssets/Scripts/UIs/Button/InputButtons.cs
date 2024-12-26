using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// ��������{�^���̃I�u�W�F�N�g���܂Ƃ߂ĊǗ�����N���X
    /// �{�^���̐e�I�u�W�F�N�g�ɃA�^�b�`����z��
    /// </summary>
    public class InputButtons : MonoBehaviour
    {

        //�I�����Ă�ꏊ��������摜��L���ɂ��邩���Ȃ����̃t���O
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
