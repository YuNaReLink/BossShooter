using UnityEngine;

namespace CreateScript
{
    public class ResultController : MonoBehaviour
    {
        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameMode.Result);
        }
    }
}
