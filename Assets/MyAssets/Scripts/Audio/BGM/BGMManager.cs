using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// BGMの再生＆停止の処理を行う
    /// BGMChangerから使うクラス
    /// 直接使うものではない
    /// </summary>
    public class BGMManager
    {
        //BGMの再生
        //再生用のオブジェクトを生成し、引数で受け取ったクリップを再生するように命令する。
        public static void Play(AudioClip clip)
        {
            if (clip == null)
            {
                Stop();
                return;
            }

            BGMPlayer player = BGMPlayer.Instance;

            if (player == null)
            {
                player = new GameObject("BGM Player").AddComponent<BGMPlayer>();
            }

            //再生開始
            player.Play(clip);
        }

        //BGMの停止
        public static void Stop()
        {
            BGMPlayer.Instance?.Stop();
        }
    }
}
