using UnityEngine;

namespace CreateScript
{
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
