using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * �{�^���P�̂ɃA�^�b�`����N���X
     * �L�[�ƃp�b�h�����̑�����s����悤�ɂ���N���X
     */
    public class InputActionButton : MonoBehaviour
    {
        private RectTransform   rectTransform;
        public RectTransform    RectTransform => rectTransform;

        [SerializeField]
        private Sprite          normalButton;
        [SerializeField]
        private Sprite          pressButton;

        private Image           image;

        [SerializeField]
        private UnityEvent      onInput;
        public UnityEvent       OnInput => onInput;


        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        //�o�^���ꂽ���e�����s
        public void OnButtonInput()
        {
            OnPress();
            onInput?.Invoke();
        }
        //�{�^���̉摜��ύX
        private void OnPress()
        {
            image.sprite = pressButton;
            // ��u����true�ɂ��āA���̃t���[����false�ɖ߂�
            StartCoroutine(ReturnNormal());
        }
        //0.1�b��������{�^���̉摜�����ɖ߂�
        private System.Collections.IEnumerator ReturnNormal()
        {
            yield return new WaitForSecondsRealtime(0.1f); // 1�t���[���҂�
            image.sprite = normalButton;
        }
    }
}
