using UnityEngine;

namespace CreateScript
{
    public class BGMChanger : MonoBehaviour
    {
        [SerializeField]
        private AudioClip clip = null;

        private void Start()
        {
            BGMManager.Play(clip);
            Destroy(gameObject);
        }
    }
}
