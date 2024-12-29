using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// 結果シーンの管理を行うクラス
    /// </summary>
    public class ResultController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip   clearClip;
        [SerializeField]
        private AudioClip   overClip;

        private void Awake()
        {
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

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameMode.Result);
        }
    }
}
