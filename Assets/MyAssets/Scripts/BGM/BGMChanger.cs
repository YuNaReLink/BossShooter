using UnityEngine;

namespace CreateScript
{
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
