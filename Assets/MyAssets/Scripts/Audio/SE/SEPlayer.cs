using UnityEngine;

namespace CreateScript
{
    //効果音を鳴らすためだけのコンポーネント
    //空のオブジェクトに括り付けて使う前提のため、鳴り終わるとオブジェクトごと消える。
    //当然ながら鳴らすための機能を要求する。
    [RequireComponent(typeof(AudioSource))]
    public class SEPlayer : MonoBehaviour
    {
        //本体
        private AudioSource source = null;

        private void Awake()
        {
            //生成時に機能を取得しておく。
            source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            //鳴っていなければ消える。
            if (!source.isPlaying)
            {
                Destroy(gameObject);
            }
        }



        //クリップを指定して再生する。
        public void Play(AudioClip clip,float volum)
        {
            source.clip = clip;
            source.volume = volum;
            source.Play();
        }
    }
}
