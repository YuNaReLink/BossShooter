using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CreateScript
{
    /// <summary>
    /// ボタン単体にアタッチするクラス
    /// キーとパッドだけの操作を行えるようにするクラス
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
            // 一瞬だけtrueにして、次のフレームでfalseに戻す
            StartCoroutine(ReturnNormal());
        }
        private System.Collections.IEnumerator ReturnNormal()
        {
            yield return new WaitForSeconds(0.1f); // 1フレーム待つ
            image.sprite = normalButton;
        }
    }
}
