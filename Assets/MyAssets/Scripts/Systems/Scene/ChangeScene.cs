using UnityEngine;

namespace CreateScript
{
    public class ChangeScene : MonoBehaviour
    {
        [SerializeField]
        private SceneList nextScene;

        public void SetNextScene()
        {
            SceneChanger.Instance.SetNextScene(nextScene);
        }
    }
}
