using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CreateScript
{
    /*
     * ボタン単体にアタッチするクラス
     * キーとパッドだけの操作を行えるようにするクラス
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

        //登録された内容を実行
        public void OnButtonInput()
        {
            OnPress();
            onInput?.Invoke();
        }
        //ボタンの画像を変更
        private void OnPress()
        {
            image.sprite = pressButton;
            // 一瞬だけtrueにして、次のフレームでfalseに戻す
            StartCoroutine(ReturnNormal());
        }
        //0.1秒たったらボタンの画像を元に戻す
        private System.Collections.IEnumerator ReturnNormal()
        {
            yield return new WaitForSecondsRealtime(0.1f); // 1フレーム待つ
            image.sprite = normalButton;
        }
    }
}
