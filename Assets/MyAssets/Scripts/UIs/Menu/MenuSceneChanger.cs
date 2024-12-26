using UnityEngine;

namespace CreateScript
{
    public class MenuSceneChanger : MonoBehaviour
    {
        [SerializeField]
        private InputActionButton inputActionButton;

        private void Awake()
        {
            inputActionButton = GetComponent<InputActionButton>();
            inputActionButton.OnInput.AddListener(SceneChanger.Instance.OnChangeScene);
        }
        // Start is called before the first frame update
        void Start()
        {
            Destroy(this);
        }
    }

}
