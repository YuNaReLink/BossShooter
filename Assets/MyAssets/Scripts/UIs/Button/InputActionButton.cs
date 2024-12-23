using UnityEngine;
using UnityEngine.Events;

namespace CreateScript
{
    public class InputActionButton : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onInput;

        private RectTransform rectTransform;

        public RectTransform RectTransform => rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnInputButton()
        {
            onInput?.Invoke();
        }
    }
}
