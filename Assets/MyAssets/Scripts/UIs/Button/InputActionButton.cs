using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// �{�^���P�̂ɃA�^�b�`����N���X
    /// �L�[�ƃp�b�h�����̑�����s����悤�ɂ���N���X
    /// </summary>
    public class InputActionButton : MonoBehaviour
    {
        private RectTransform rectTransform;
        public RectTransform RectTransform => rectTransform;

        [SerializeField]
        private Sprite normalButton;
        [SerializeField]
        private Sprite pressButton;

        private Image image;

        [SerializeField]
        private UnityEvent onInput;


        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        public void OnButtonInput()
        {
            OnPress();
            onInput?.Invoke();
        }
        private void OnPress()
        {
            image.sprite = pressButton;
            // ��u����true�ɂ��āA���̃t���[����false�ɖ߂�
            StartCoroutine(ReturnNormal());
        }
        private System.Collections.IEnumerator ReturnNormal()
        {
            yield return new WaitForSeconds(0.1f); // 1�t���[���҂�
            image.sprite = normalButton;
        }
    }
}
