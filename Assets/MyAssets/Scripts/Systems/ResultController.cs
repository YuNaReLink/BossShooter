using UnityEngine;

namespace CreateScript
{
    /*
     * ���ʃV�[���̊Ǘ����s���N���X
     */
    public class ResultController : MonoBehaviour
    {
        //Over��Clear����BGM�������Ă���
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
