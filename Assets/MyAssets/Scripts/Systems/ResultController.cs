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
            GlobalManager.Instance.SetGameMode(GameMode.Result);

            //��̃I�u�W�F�N�g�𐶐�����B
            GameObject o = new("BGM");
            //�R���|�[�l���g������t����B
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
