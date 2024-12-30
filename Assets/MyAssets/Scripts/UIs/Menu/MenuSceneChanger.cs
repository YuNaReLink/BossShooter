using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ���j���[���������ꂽ���Ɠ����Ƀ{�^���ɃV�[���J�ڃC�x���g��ݒ肷��N���X
    /// </summary>
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
        private void Start()
        {
            Destroy(this);
        }
    }

}
