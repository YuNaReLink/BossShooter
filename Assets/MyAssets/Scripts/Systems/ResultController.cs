using UnityEngine;

namespace CreateScript
{
    /*
     * 結果シーンの管理を行うクラス
     */
    public class ResultController : MonoBehaviour
    {
        //OverとClear時のBGMを持っている
        [SerializeField]
        private AudioClip   clearClip;
        [SerializeField]
        private AudioClip   overClip;

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameScene.Result);

            AudioClip clip = null;
            switch (GlobalManager.Instance.ResultType)
            {
                case ResultType.GameClear:
                    clip = clearClip;
                    break;
                case ResultType.GameOver:
                    clip = overClip;
                    break;
                default:
                    clip = overClip;
                    break;
            }
            BGMManager.Play(clip);
            BGMManager.SetLoop(false);
        }
    }
}
