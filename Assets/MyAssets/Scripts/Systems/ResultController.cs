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
            GlobalManager.Instance.SetGameMode(GameMode.Result);

            //空のオブジェクトを生成する。
            GameObject o = new("BGM");
            //コンポーネントを括り付ける。
            BGMChanger bgm = o.AddComponent<BGMChanger>();
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
            bgm.SetClip(clip);
        }
    }
}
