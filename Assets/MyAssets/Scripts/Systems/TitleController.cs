using UnityEngine;

namespace CreateScript
{
    public class TitleController : MonoBehaviour
    {

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameMode.Title);
            ScoreSystem.Instance.ResetScore();
        }
    }
}
