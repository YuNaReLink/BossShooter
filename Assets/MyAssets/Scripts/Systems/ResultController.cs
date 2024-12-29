using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// ���ʃV�[���̊Ǘ����s���N���X
    /// </summary>
    public class ResultController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip   clearClip;
        [SerializeField]
        private AudioClip   overClip;

        private void Awake()
        {
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

        private void Start()
        {
            GlobalManager.Instance.SetGameMode(GameMode.Result);
        }
    }
}
