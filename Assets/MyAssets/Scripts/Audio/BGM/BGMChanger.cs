using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// オブジェクトにアタッチしてセットしたBGMに変更するクラス
    /// Start時にBGMManagerでBGMPlayerが呼び出される
    /// オブジェクトにアタッチして使うもの
    /// BGMを再生するならこのクラスアタッチ
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
