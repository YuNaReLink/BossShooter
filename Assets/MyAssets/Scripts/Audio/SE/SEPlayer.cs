using UnityEngine;

namespace CreateScript
{
    //���ʉ���炷���߂����̃R���|�[�l���g
    //��̃I�u�W�F�N�g�Ɋ���t���Ďg���O��̂��߁A��I���ƃI�u�W�F�N�g���Ə�����B
    //���R�Ȃ���炷���߂̋@�\��v������B
    [RequireComponent(typeof(AudioSource))]
    public class SEPlayer : MonoBehaviour
    {
        //�{��
        private AudioSource source = null;

        private void Awake()
        {
            //�������ɋ@�\���擾���Ă����B
            source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            //���Ă��Ȃ���Ώ�����B
            if (!source.isPlaying)
            {
                Destroy(gameObject);
            }
        }



        //�N���b�v���w�肵�čĐ�����B
        public void Play(AudioClip clip,float volum)
        {
            source.clip = clip;
            source.volume = volum;
            source.Play();
        }
    }
}
