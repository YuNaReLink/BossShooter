using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// メニューが生成された時と同時にボタンにシーン遷移イベントを設定するクラス
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
