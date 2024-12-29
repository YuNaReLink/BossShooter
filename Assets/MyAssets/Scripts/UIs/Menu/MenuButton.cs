using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// メニューで使用するボタン単体の処理
    /// </summary>
    public class MenuButton : MonoBehaviour
    {
        [SerializeField]
        private InputActionButton button;

        private void Awake()
        {
            button = GetComponent<InputActionButton>();
        }

        private void Update()
        {
            if (!InputUIAction.Instance.Pause) { return; }
            button.OnButtonInput();
        }
    }
}
