using UnityEngine;

namespace CreateScript
{
    /// <summary>
    /// BGM�̍Đ�����~�̏������s��
    /// BGMChanger����g���N���X
    /// ���ڎg�����̂ł͂Ȃ�
    /// </summary>
    public class BGMManager
    {
        //BGM�̍Đ�
        //�Đ��p�̃I�u�W�F�N�g�𐶐����A�����Ŏ󂯎�����N���b�v���Đ�����悤�ɖ��߂���B
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

            //�Đ��J�n
            player.Play(clip);
        }

        //BGM�̒�~
        public static void Stop()
        {
            BGMPlayer.Instance?.Stop();
        }
    }
}
