using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// �I�u�W�F�N�g�ɃA�^�b�`���ăZ�b�g����BGM�ɕύX����N���X
    /// Start����BGMManager��BGMPlayer���Ăяo�����
    /// </summary>
    public class BGMChanger : MonoBehaviour
    {
        [SerializeField]
        private AudioClip clip = null;
        public void SetClip(AudioClip c) { clip = c; } 

        private void Start()
        {
            BGMManager.Play(clip);
            Destroy(gameObject);
        }
    }
}
